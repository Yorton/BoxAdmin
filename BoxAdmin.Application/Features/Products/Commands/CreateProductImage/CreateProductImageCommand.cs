using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MediatR;

namespace BoxAdmin.Application.Features.Products.Commands.CreateProductImage
{
    using BoxAdmin.Application.Interfaces.Contexts;
    using BoxAdmin.Application.Interfaces.Shared;
    using BoxAdmin.Domain.Entities.BoxContext;

    public class CreateProductImageCommand : IRequest<CreateProductImageResponse>
    {
        public string SeriesNo { get; set; }
        public List<CreateProductImageDto> Images { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductImageCommand, CreateProductImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public CreateProductCommandHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<CreateProductImageResponse> Handle(CreateProductImageCommand command, CancellationToken cancellationToken)
        {
            var response = new CreateProductImageResponse();

            var seriesQuery = await _context.ProductSeries.SingleOrDefaultAsync(s => s.Series == command.SeriesNo, cancellationToken)
                ?? throw new ArgumentException($"查無資料");

            // 商品圖(含色塊)
            var productImagesQuery = await _context.ProductImages.Where(s => s.Series == seriesQuery.Series).ToListAsync();

            var newImage = (
                from a in command.Images
                join b in productImagesQuery on new { a.Color, a.Type, a.Sort } equals new { b.Color, b.Type, b.Sort } into ab
                from obj in ab.DefaultIfEmpty()
                where obj == null
                select a).ToList();

            var updateImageObj = (
                from a in command.Images
                join b in productImagesQuery on new { a.Color, a.Type, a.Sort } equals new { b.Color, b.Type, b.Sort }
                select new
                {
                    SrcImage = a,
                    DestImage = b
                }).ToList();

            var deleteImage = (
                from a in productImagesQuery
                join b in command.Images on new { a.Color, a.Type, a.Sort } equals new { b.Color, b.Type, b.Sort } into ab
                from obj in ab.DefaultIfEmpty()
                where obj == null
                select a).ToList();

            foreach (var img in newImage)
            {
                _context.ProductImages.Add(new ProductImage()
                {
                    Series = command.SeriesNo,
                    Color = img.Color,
                    ImagePath = img.ImagePath,
                    Sort = img.Sort,
                    Type = img.Type,
                    Filename = img.Name,
                    CreatedDate = DateTime.Now,
                    Creator = "BOT",
                    ModifyDate = DateTime.Now,
                    Modifier = "BOT",
                });
            }

            foreach (var imgObj in updateImageObj)
            {
                var updateImageEntity = await _context.ProductImages.SingleOrDefaultAsync(s =>
                    s.Series == imgObj.DestImage.Series
                    && s.Color == imgObj.DestImage.Color
                    && s.Type == imgObj.DestImage.Type
                    && s.Sort == imgObj.DestImage.Sort);

                updateImageEntity.Filename = imgObj.SrcImage.Name ?? "";
                updateImageEntity.ImagePath = imgObj.SrcImage.ImagePath ?? "";
                updateImageEntity.Modifier = "BOT";
                updateImageEntity.ModifyDate = DateTime.Now;
            }

            foreach (var img in deleteImage) 
            {
                var updateImageEntity = await _context.ProductImages.SingleOrDefaultAsync(s => 
                    s.Series == img.Series 
                    && s.Color == img.Color 
                    && s.Type == img.Type 
                    && s.Sort == img.Sort);

                _context.ProductImages.Remove(img);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return response;
        }
    }

    public class CreateProductImageResponse
    {
    }
}
