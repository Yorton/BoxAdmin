using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using Swashbuckle.AspNetCore.Annotations;
using AutoMapper;
using MediatR;

using BoxAdmin.Framework.Results;
using BoxAdmin.Application.Interfaces.Contexts;
using BoxAdmin.Application.DTOs.Settings;
using System.Threading;
using BoxAdmin.Domain.Entities.BoxContext;
using Newtonsoft.Json;
using System.Reflection;

namespace BoxAdmin.Application.Features.BoxOrders.Queries.GetBoxSurveyAnswer
{
    public class GetBoxSurveyAnswerQuery : IRequest<List<GetBoxSurveyAnswerResponse>>
    {
        /// <summary>
        /// 會員ID
        /// </summary>
        [SwaggerParameter(Description = "會員ID")]
        public string CustomerId { get; set; }

        /// <summary>
        /// BoxID
        /// </summary>
        [SwaggerParameter(Description = "BoxID")]
        public string ReservationId { get; set; }

        /// <summary>
        /// 問卷類型
        /// </summary>
        [SwaggerParameter(Description = "問卷類型")]
        public string SurveyAnswerType { get; set; }
    }

    public class GetBoxSurveyAnswerQueryHandler : IRequestHandler<GetBoxSurveyAnswerQuery, List<GetBoxSurveyAnswerResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetBoxSurveyAnswerQueryHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<GetBoxSurveyAnswerResponse>> Handle(GetBoxSurveyAnswerQuery command, CancellationToken cancellationToken)
        {
            List<GetBoxSurveyAnswerResponse> list = null;

            #region 問卷A
            if (command.SurveyAnswerType == "A") 
            {
                Guid surveyId = _context.Surveys.FirstOrDefault(x => x.Name == "問卷A").Id;

                var queryable = await (from sa in _context.SurveyAnswers
                                       where sa.SurveyId == surveyId && sa.CustomerId == Guid.Parse(command.CustomerId)
                                       select new
                                       {
                                           TopicNo1 = sa.TopicNo1,
                                           TopicNo2 = sa.TopicNo2,
                                           Answer = sa.Answer
                                       }).ToListAsync(cancellationToken);

                List<SurveyTitle> surveyTitleList = _context.SurveyTitles.Where(x => x.SurveyId == surveyId
                                                                                  && x.SurveyType == "A").ToList();

                List<SurveyTitleMapping> surveyTitleMappingList = _context.SurveyTitleMappings.
                                                                    Where(x => x.SurveyId == surveyId
                                                                            && x.SurveyType == "A").ToList();

                if (queryable != null && queryable.Count > 0)
                    list = new List<GetBoxSurveyAnswerResponse>(); 
                else 
                    return null;

                #region Answer-1

                List<SurveyTitle> surveyTitleList_1 = surveyTitleList.Where(x => x.No == 1).ToList();

                string answer1 = queryable.First(x => x.TopicNo1 == "1").Answer ?? "";

                LikeLevel surveyAnswerA1 = JsonConvert.DeserializeObject<LikeLevel>(answer1);

                foreach (SurveyTitle surveyTitle in surveyTitleList_1)
                {
                    string answer = GetAnswer(surveyAnswerA1, surveyTitleMappingList, 1, surveyTitle.SubNo, "A1");

                    GetBoxSurveyAnswerResponse response = new GetBoxSurveyAnswerResponse();
                    response.No = surveyTitle.No.ToString();
                    response.NoName = surveyTitle.NoName;
                    response.SubNoName = surveyTitle.SubNoName;
                    response.Answer = answer;
                    list.Add(response);
                }

                #endregion

                #region Answer-2,Answer-3,Answer-4
                for (int i = 2; i <= 4; i++)
                {
                    List<SurveyTitle> surveyTitleList_2 = surveyTitleList.Where(x => x.No == i).ToList();
 
                    string answer2 = queryable.First(x => x.TopicNo1 == i.ToString()).Answer ?? "";

                    List<string> answerList = JsonConvert.DeserializeObject<List<string>>(answer2);

                    string answer = GetAnswer(answerList, surveyTitleMappingList, i, "", "A" + i);

                    GetBoxSurveyAnswerResponse response = new GetBoxSurveyAnswerResponse();
                    response.No = surveyTitleList_2[0].No.ToString();
                    response.NoName = surveyTitleList_2[0].NoName;
                    response.SubNoName = null;
                    response.Answer = answer;
                    list.Add(response);
                }
                #endregion

                #region Answer-5,Answer-6
                for (int i = 5; i <= 6; i++)
                {
                    List<SurveyTitle> surveyTitleList_5 = surveyTitleList.Where(x => x.No == i).ToList();

                    string answer5 = queryable.First(x => x.TopicNo1 == i.ToString()).Answer ?? "";

                    BodySize surveyAnswerA5 = JsonConvert.DeserializeObject<BodySize>(answer5);

                    foreach (SurveyTitle surveyTitle in surveyTitleList_5)
                    {
                        string answer = GetAnswer(surveyAnswerA5, surveyTitleMappingList, i, surveyTitle.SubNo, "A" + i);

                        GetBoxSurveyAnswerResponse response = new GetBoxSurveyAnswerResponse();
                        response.No = surveyTitle.No.ToString();
                        response.NoName = surveyTitle.NoName;
                        response.SubNoName = surveyTitle.SubNoName;
                        response.Answer = answer;
                        list.Add(response);
                    }
                }
                #endregion

                #region Answer-7
                List<SurveyTitle> surveyTitleList_7 = surveyTitleList.Where(x => x.No == 7).ToList();

                string answer7 = queryable.First(x => x.TopicNo1 == "7").Answer ?? "";

                ClothesSize surveyAnswerA7 = JsonConvert.DeserializeObject<ClothesSize>(answer7);

                foreach (SurveyTitle surveyTitle in surveyTitleList_7)
                {
                    string answer = GetAnswer(surveyAnswerA7, surveyTitleMappingList, 7, surveyTitle.SubNo, "A7");

                    GetBoxSurveyAnswerResponse response = new GetBoxSurveyAnswerResponse();
                    response.No = surveyTitle.No.ToString();
                    response.NoName = surveyTitle.NoName;
                    response.SubNoName = surveyTitle.SubNoName;
                    response.Answer = answer;
                    list.Add(response);
                }
                #endregion

                #region Answer-8
                List<SurveyTitle> surveyTitleList_8 = surveyTitleList.Where(x => x.No == 8).ToList();
                List<SurveyTitleMapping> surveyTitleMappingList_8 = surveyTitleMappingList.Where(x => x.No == 8).ToList();

                string answer8 = queryable.First(x => x.TopicNo1 == "8").Answer ?? "";
                answer8 = answer8.Replace("\"", "");
                string answerName8 = surveyTitleMappingList_8.FirstOrDefault(x => x.Answer == answer8).AnswerName;

                GetBoxSurveyAnswerResponse Answer_A_Response_8 = new GetBoxSurveyAnswerResponse();
                Answer_A_Response_8.No = surveyTitleList_8[0].No.ToString();
                Answer_A_Response_8.NoName = surveyTitleList_8[0].NoName;
                Answer_A_Response_8.SubNoName = null;
                Answer_A_Response_8.Answer = answerName8 != null ? answerName8 : "無";
                list.Add(Answer_A_Response_8);
                #endregion

                #region Answer-9
                List<SurveyTitle> surveyTitleList_9 = surveyTitleList.Where(x => x.No == 9).ToList();

                string dbAnswer9 = queryable.First(x => x.TopicNo1 == "9").Answer ?? "";

                List<string> answer9List = JsonConvert.DeserializeObject<List<string>>(dbAnswer9);

                string answer9 = GetAnswer(answer9List, surveyTitleMappingList, 9, "", "A9");

                GetBoxSurveyAnswerResponse response9 = new GetBoxSurveyAnswerResponse();
                response9.No = surveyTitleList_9[0].No.ToString();
                response9.NoName = surveyTitleList_9[0].NoName;
                response9.SubNoName = null;
                response9.Answer = answer9;
                list.Add(response9);
                #endregion

                #region Answer-10
                List<SurveyTitle> surveyTitleList_10 = surveyTitleList.Where(x => x.No == 10).ToList();
            
                string answer10 = queryable.First(x => x.TopicNo1 == "10").Answer ?? "";

                BodyShape surveyAnswerA10 = JsonConvert.DeserializeObject<BodyShape>(answer10);

                foreach (SurveyTitle surveyTitle in surveyTitleList_10)
                {
                    string answer = GetAnswer(surveyAnswerA10, surveyTitleMappingList, 10, surveyTitle.SubNo, "A10");

                    GetBoxSurveyAnswerResponse response = new GetBoxSurveyAnswerResponse();
                    response.No = surveyTitle.No.ToString();
                    response.NoName = surveyTitle.NoName;
                    response.SubNoName = surveyTitle.SubNoName;
                    response.Answer = answer;
                    list.Add(response);
                }

                #endregion

                #region Answer-11
                List<SurveyTitle> surveyTitleList_11 = surveyTitleList.Where(x => x.No == 11).ToList();
                List<SurveyTitleMapping> surveyTitleMappingList_11 = surveyTitleMappingList.Where(x => x.No == 11).ToList();

                string answer11 = queryable.First(x => x.TopicNo1 == "11").Answer ?? "";
                answer11 = answer11.Replace("\"", "");
                string answerName11 = surveyTitleMappingList_11.FirstOrDefault(x => x.Answer == answer11).AnswerName; 
               
                GetBoxSurveyAnswerResponse response11 = new GetBoxSurveyAnswerResponse();
                response11.No = surveyTitleList_11[0].No.ToString();
                response11.NoName = surveyTitleList_11[0].NoName;
                response11.SubNoName = null;
                response11.Answer = answerName11 != null ? answerName11 : "無";
                list.Add(response11);
                #endregion

                #region Answer-12,Answer-13,Answer-14

                for (int i = 12; i <= 14; i++) 
                {
                    List<SurveyTitle> surveyTitleList_12 = surveyTitleList.Where(x => x.No == i).ToList();

                    string answer12 = queryable.First(x => x.TopicNo1 == i.ToString()).Answer ?? "";

                    Gerneric1 surveyAnswerA12 = null;
                    if (i == 12)
                    {
                        surveyAnswerA12 = JsonConvert.DeserializeObject<PantFit>(answer12);
                    }
                    if (i == 13) 
                    {
                        surveyAnswerA12 = JsonConvert.DeserializeObject<PantLength>(answer12);
                    }
                    if (i == 14)
                    {
                        surveyAnswerA12 = JsonConvert.DeserializeObject<PantTop>(answer12);
                    }

                    foreach (SurveyTitle SurveyTitle in surveyTitleList_12)
                    {
                        string answer = GetAnswer(surveyAnswerA12, surveyTitleMappingList, i, SurveyTitle.SubNo, "A" + i);

                        GetBoxSurveyAnswerResponse response = new GetBoxSurveyAnswerResponse();
                        response.No = SurveyTitle.No.ToString();
                        response.NoName = SurveyTitle.NoName;
                        response.SubNoName = SurveyTitle.SubNoName;
                        response.Answer = answer;
                        list.Add(response);
                    }
                }
                #endregion

                #region Answer-15
                List<SurveyTitle> surveyTitleList_15 = surveyTitleList.Where(x => x.No == 15).ToList();

                string dbAnswer15 = queryable.First(x => x.TopicNo1 == "15").Answer ?? "";

                List<string> answer15List = JsonConvert.DeserializeObject<List<string>>(dbAnswer15);

                string answer15 = GetAnswer(answer15List, surveyTitleMappingList, 15, "", "A15");

                GetBoxSurveyAnswerResponse response15 = new GetBoxSurveyAnswerResponse();
                response15.No = surveyTitleList_15[0].No.ToString();
                response15.NoName = surveyTitleList_15[0].NoName;
                response15.SubNoName = null;
                response15.Answer = answer15;
                list.Add(response15);
                #endregion

                #region Answer-16
                List<SurveyTitle> surveyTitleList_16 = surveyTitleList.Where(x => x.No == 16).ToList();
                List<SurveyTitleMapping> surveyTitleMappingList_16 = surveyTitleMappingList.Where(x => x.No == 16).ToList();

                string answer16 = queryable.First(x => x.TopicNo1 == "16").Answer ?? "";
                answer16 = answer16.Replace("\"", "");
                string answerName16 = surveyTitleMappingList_16.FirstOrDefault(x => x.Answer == answer16).AnswerName;
               
                GetBoxSurveyAnswerResponse response16 = new GetBoxSurveyAnswerResponse();
                response16.No = surveyTitleList_16[0].No.ToString();
                response16.NoName = surveyTitleList_16[0].NoName;
                response16.SubNoName = null;
                response16.Answer = answerName16 != null ? answerName16 : "無";
                list.Add(response16);
                #endregion

                #region Answer-17
                List<SurveyTitle> surveyTitleList_17 = surveyTitleList.Where(x => x.No == 17).ToList();

                string answer17 = queryable.First(x => x.TopicNo1 == "17").Answer ?? "";

                ClothesPrice surveyAnswerA17 = JsonConvert.DeserializeObject<ClothesPrice>(answer17);

                foreach (SurveyTitle surveyTitle in surveyTitleList_17)
                {
                    string answer = GetAnswer(surveyAnswerA17, surveyTitleMappingList, 17, surveyTitle.SubNo, "A17");

                    GetBoxSurveyAnswerResponse response = new GetBoxSurveyAnswerResponse();
                    response.No = surveyTitle.No.ToString();
                    response.NoName = surveyTitle.NoName;
                    response.SubNoName = surveyTitle.SubNoName;
                    response.Answer = answer;
                    list.Add(response);
                }
                #endregion

                #region Answer-18,Answer-19
                for (int i = 18; i <= 19; i++)
                {
                    List<SurveyTitle> surveyTitleList_18 = surveyTitleList.Where(x => x.No == i).ToList();
                    List<SurveyTitleMapping> surveyTitleMappingList_18 = surveyTitleMappingList.Where(x => x.No == i).ToList();

                    string answer18 = queryable.First(x => x.TopicNo1 == i.ToString()).Answer ?? "";
                    answer18 = answer18.Replace("\"", "");
                    string answerName18 = surveyTitleMappingList_18.FirstOrDefault(x => x.Answer == answer18).AnswerName;
               
                    GetBoxSurveyAnswerResponse response = new GetBoxSurveyAnswerResponse();
                    response.No = surveyTitleList_18[0].No.ToString();
                    response.NoName = surveyTitleList_18[0].NoName;
                    response.SubNoName = null;
                    response.Answer = answerName18 != "" ? answerName18 : "無";
                    list.Add(response);
                }
                #endregion

                #region Answer-20
                List<SurveyTitle> surveyTitleList_20 = surveyTitleList.Where(x => x.No == 20).ToList();

                string answer20 = queryable.First(x => x.TopicNo1 == "20").Answer ?? "";

                iSheboxExperience surveyAnswerA20 = JsonConvert.DeserializeObject<iSheboxExperience>(answer20);

                foreach (SurveyTitle surveyTitle in surveyTitleList_20)
                {
                    string answer = GetAnswer(surveyAnswerA20, surveyTitleMappingList, 20, surveyTitle.SubNo, "A20");

                    GetBoxSurveyAnswerResponse response = new GetBoxSurveyAnswerResponse();
                    response.No = surveyTitle.No.ToString();
                    response.NoName = surveyTitle.NoName;
                    response.SubNoName = surveyTitle.SubNoName;
                    response.Answer = answer;
                    list.Add(response);
                }

                #endregion

                #region Answer-21
                List<SurveyTitle> surveyTitleList_21 = surveyTitleList.Where(x => x.No == 21).ToList();

                string answer21 = queryable.First(x => x.TopicNo1 == "21").Answer ?? "";

                GetBoxSurveyAnswerResponse response21 = new GetBoxSurveyAnswerResponse();
                response21.No = surveyTitleList_21[0].No.ToString();
                response21.NoName = surveyTitleList_21[0].NoName;
                response21.SubNoName = null;
                response21.Answer = answer21 != "" ? answer21.Replace("\"", "") : "無";
                list.Add(response21);
                #endregion

                #region Answer-22
                List<SurveyTitle> surveyTitleList_22 = surveyTitleList.Where(x => x.No == 22).ToList();

                string answer22 = queryable.First(x => x.TopicNo1 == "22").Answer ?? "";

                Job surveyAnswerA22 = JsonConvert.DeserializeObject<Job>(answer22);

                foreach (SurveyTitle surveyTitle in surveyTitleList_22)
                {
                    string answer = GetAnswer(surveyAnswerA22, surveyTitleMappingList, 22, surveyTitle.SubNo, "A22");

                    GetBoxSurveyAnswerResponse response = new GetBoxSurveyAnswerResponse();
                    response.No = surveyTitle.No.ToString();
                    response.NoName = surveyTitle.NoName;
                    response.SubNoName = surveyTitle.SubNoName;
                    response.Answer = answer;
                    list.Add(response);
                }

                #endregion

                #region Answer-23,Answer-24
                for (int i = 23; i <= 24; i++)
                {
                    List<SurveyTitle> surveyTitleList_23 = surveyTitleList.Where(x => x.No == i).ToList();
                    List<SurveyTitleMapping> surveyTitleMappingList_23 = surveyTitleMappingList.Where(x => x.No == i).ToList();

                    string answer23 = queryable.First(x => x.TopicNo1 == i.ToString()).Answer ?? "";
                    answer23 = answer23.Replace("\"", "");
                    string answerName23 = surveyTitleMappingList_23.FirstOrDefault(x => x.Answer == answer23).AnswerName;
                  
                    GetBoxSurveyAnswerResponse response = new GetBoxSurveyAnswerResponse();
                    response.No = surveyTitleList_23[0].No.ToString();
                    response.NoName = surveyTitleList_23[0].NoName;
                    response.SubNoName = null;
                    response.Answer = answerName23 != null ? answerName23 : "無";
                    list.Add(response);
                }

                #endregion
            }
            #endregion

            #region 問卷B
            if (command.SurveyAnswerType == "B")
            {
                Guid surveyId = _context.Surveys.FirstOrDefault(x => x.Name == "問卷B").Id;

                var queryable = await (from sa in _context.SurveyAnswers
                                       join s in _context.Surveys on new { SurveyId1 = sa.SurveyId, SurveyId2 = surveyId } 
                                                              equals new { SurveyId1 = s.Id, SurveyId2 = s.Id } 
                                       join sr in _context.SurveyReplies on sa.SurveyReplyId equals sr.SurveyReplyId  
                                       join r in _context.Reservations on new { ReservationId = sr.SourceId, CustomerId = sa.CustomerId}
                                                                   equals new { ReservationId = r.Id, CustomerId = r.CustomerId}
                                       where sa.CustomerId == Guid.Parse(command.CustomerId) 
                                                   && r.Id == Guid.Parse(command.ReservationId)
                                          && sr.SourceType == 1 //SourceType: 1=盒子 2=訂閱
                                       select new
                                       {
                                           TopicNo1 = sa.TopicNo1,
                                           TopicNo2 = sa.TopicNo2,
                                           Answer = sa.Answer
                                       }).ToListAsync(cancellationToken);

                List<SurveyTitle> surveyTitleList = _context.SurveyTitles.Where(x => x.SurveyId == surveyId
                                                                                  && x.SurveyType == "B").ToList();

                List<SurveyTitleMapping> surveyTitleMappingList = _context.SurveyTitleMappings.
                                                                    Where(x => x.SurveyId == surveyId
                                                                            && x.SurveyType == "B").ToList();

                if (queryable != null && queryable.Count > 0) 
                    list = new List<GetBoxSurveyAnswerResponse>(); 
                else 
                    return null;

                #region Answer-1, Answer-2, Answer-3

                for (int i = 1; i <= 3; i++)
                {
                    List<SurveyTitle> surveyTitleList_B = surveyTitleList.Where(x => x.No == i).ToList();

                    string answerB = queryable.First(x => x.TopicNo1 == i.ToString()).Answer ?? "";

                    object surveyAnswerB = null;

                    if (i == 1) 
                    {
                        surveyAnswerB = JsonConvert.DeserializeObject<Occasion>(answerB);
                    }
                    if (i == 2)
                    {
                        surveyAnswerB = JsonConvert.DeserializeObject<BoxItems>(answerB); 
                    }
                    if (i == 3)
                    {
                        surveyAnswerB = JsonConvert.DeserializeObject<LikeLevel>(answerB);
                    }

                    foreach (SurveyTitle surveyTitle in surveyTitleList_B)
                    {
                        string answer = GetAnswer(surveyAnswerB, surveyTitleMappingList, i, surveyTitle.SubNo, "B" + i);

                        GetBoxSurveyAnswerResponse response = new GetBoxSurveyAnswerResponse();
                        response.No = surveyTitle.No.ToString();
                        response.NoName = surveyTitle.NoName;
                        response.SubNoName = surveyTitle.SubNoName;
                        response.Answer = answer;
                        list.Add(response);
                    }
                }
                #endregion

                #region Answer-4
                List<SurveyTitle> surveyTitleList_4 = surveyTitleList.Where(x => x.No == 4).ToList();

                string answer4 = queryable.First(x => x.TopicNo1 == "4").Answer ?? "";

                GetBoxSurveyAnswerResponse response4 = new GetBoxSurveyAnswerResponse();
                response4.No = surveyTitleList_4[0].No.ToString();
                response4.NoName = surveyTitleList_4[0].NoName;
                response4.SubNoName = null;
                response4.Answer = answer4 != "" ? answer4.Replace("\"", "") : "無";
                list.Add(response4);
                #endregion
            }
            #endregion

            #region 問卷C
            if (command.SurveyAnswerType == "C")
            {
                Guid surveyId = _context.Surveys.FirstOrDefault(x => x.Name == "問卷C").Id;

                var queryable = await (from sa in _context.SurveyAnswers
                                       join s in _context.Surveys on new { SurveyId1 = sa.SurveyId, SurveyId2 = surveyId }
                                                              equals new { SurveyId1 = s.Id, SurveyId2 = s.Id }
                                       join sr in _context.SurveyReplies on sa.SurveyReplyId equals sr.SurveyReplyId
                                       join r in _context.Reservations on new { ReservationId = sr.SourceId, CustomerId = sa.CustomerId }
                                                                   equals new { ReservationId = r.Id, CustomerId = r.CustomerId }
                                       where sa.CustomerId == Guid.Parse(command.CustomerId)
                                                   && r.Id == Guid.Parse(command.ReservationId)
                                          && sr.SourceType == 1 //SourceType: 1=盒子 2=訂閱
                                       select new
                                       {
                                           TopicNo1 = sa.TopicNo1,
                                           TopicNo2 = sa.TopicNo2,
                                           Answer = sa.Answer
                                       }).ToListAsync(cancellationToken);

                List<SurveyTitle> surveyTitleList = _context.SurveyTitles.Where(x => x.SurveyId == surveyId
                                                                                  && x.SurveyType == "C").ToList();

                List<SurveyTitleMapping> surveyTitleMappingList = _context.SurveyTitleMappings.
                                                                    Where(x => x.SurveyId == surveyId
                                                                            && x.SurveyType == "C").ToList();

                if (queryable != null && queryable.Count > 0) 
                    list = new List<GetBoxSurveyAnswerResponse>(); 
                else 
                    return null;

                #region Answer-1,Answer-2
                for (int i = 1; i <= 2; i++)
                {
                    List<SurveyTitle> surveyTitleList_C = surveyTitleList.Where(x => x.No == i).ToList();

                    string answerC = queryable.First(x => x.TopicNo1 == i.ToString()).Answer ?? "";

                    object surveyAnswerC = null;

                    if (i == 1)
                    {
                        surveyAnswerC = JsonConvert.DeserializeObject<ProductSatisfaction>(answerC);
                    }
                    if (i == 2)
                    {
                        surveyAnswerC = JsonConvert.DeserializeObject<ClothesSuitable>(answerC);
                    }

                    foreach (SurveyTitle surveyTitle in surveyTitleList_C)
                    {
                        string answer = GetAnswer(surveyAnswerC, surveyTitleMappingList, i, surveyTitle.SubNo, "C" + i);

                        GetBoxSurveyAnswerResponse response = new GetBoxSurveyAnswerResponse();
                        response.No = surveyTitle.No.ToString();
                        response.NoName = surveyTitle.NoName;
                        response.SubNoName = surveyTitle.SubNoName;
                        response.Answer = answer;
                        list.Add(response);
                    }
                }
                #endregion

                #region Answer-3
                List<SurveyTitle> surveyTitleList_3 = surveyTitleList.Where(x => x.No == 3).ToList();

                string answer3 = queryable.First(x => x.TopicNo1 == "3").Answer ?? "";

                GetBoxSurveyAnswerResponse response3 = new GetBoxSurveyAnswerResponse();
                response3.No = surveyTitleList_3[0].No.ToString();
                response3.NoName = surveyTitleList_3[0].NoName;
                response3.SubNoName = null;
                response3.Answer = answer3 != "" ? answer3.Replace("\"", "") : "無";
                list.Add(response3);
                #endregion
            }
            #endregion

            return await Task.FromResult(list);
        }


        private string GetAnswer(object answerObj, List<SurveyTitleMapping> surveyTitleMappingList, int no, string subNo, string type)
        {
            string answer = "";

            List<SurveyTitleMapping> answerNameList = surveyTitleMappingList.Where(x => x.No == no).ToList();

            switch (type)
            {
                case "A1":
                case "B3":
                    Type a1Type = typeof(LikeLevel);
                    PropertyInfo a1PropInfo = a1Type.GetProperty("Item" + subNo);

                    string a1Ans = (answerObj != null && a1PropInfo.GetValue(answerObj, null) != null) 
                                    ? Convert.ToInt32(a1PropInfo.GetValue(answerObj, null)).ToString() : null;

                    SurveyTitleMapping surveyTitleMappingA1 = answerNameList.FirstOrDefault(x => x.Answer == a1Ans);

                    answer = surveyTitleMappingA1 != null ? surveyTitleMappingA1.AnswerName : "無";
                    break;

                case "A2":
                case "A3":
                case "A4":
                case "A9":
                case "A15":
                    List<string> a2AnswerNameList = null;
                    if (answerObj != null)
                    {
                        List<string> a2AnswerList = answerObj as List<string>;

                        a2AnswerNameList = new List<string>();

                        foreach (string itemAns in a2AnswerList)
                        {
                            SurveyTitleMapping surveyTitleMappingA2 = answerNameList.FirstOrDefault(x => x.Answer == itemAns.Replace("\"", ""));
                            a2AnswerNameList.Add(surveyTitleMappingA2 != null ? surveyTitleMappingA2.AnswerName : itemAns);
                        }
                    }
                    answer = a2AnswerNameList != null ? string.Join(",", a2AnswerNameList.ToArray()) : "無";
                    break;

                case "A5":
                case "A6":
                    Type a5Type = typeof(BodySize);
                    PropertyInfo a5PropInfo = a5Type.GetProperty(subNo);
                    answer = (answerObj != null && a5PropInfo.GetValue(answerObj, null) != null)
                             ? Convert.ToInt32(a5PropInfo.GetValue(answerObj, null)).ToString() : "無";
                    break;
                case "A7":
                    Type a7Type = typeof(ClothesSize);
                    PropertyInfo a7PropInfo = a7Type.GetProperty(subNo);

                    if (a7PropInfo.Name != "Brassier")
                    {
                        List<string> ansList = (answerObj != null && a7PropInfo.GetValue(answerObj, null) != null) 
                                                ? a7PropInfo.GetValue(answerObj, null) as List<string> : null;
                        answer = ansList != null ? string.Join(",", ansList.ToArray()) : "無";
                    }
                    else //內衣
                    {
                        Brassier brassierAns = (answerObj != null && a7PropInfo.GetValue(answerObj, null) != null) 
                                                ? a7PropInfo.GetValue(answerObj, null) as Brassier : null;

                        answer = "Bra:" + (brassierAns != null ? brassierAns.Bra : "無")
                               + " Size:" + (brassierAns != null ? string.Join(",", brassierAns.Size.ToArray()) : "無");
                    }
                    break;
                case "A10":
                    Type a10Type = typeof(BodyShape);
                    PropertyInfo a10PropInfo = a10Type.GetProperty(subNo);

                    string a10Ans = (answerObj != null && a10PropInfo.GetValue(answerObj, null) != null) 
                                    ? a10PropInfo.GetValue(answerObj, null).ToString() : null;

                    SurveyTitleMapping surveyTitleMappingA10 = answerNameList
                                                    .FirstOrDefault(x => x.SubNo == subNo
                                                    && x.Answer == a10Ans);

                    answer = surveyTitleMappingA10 != null ? surveyTitleMappingA10.AnswerName : "未選";
                    break;
                case "A12":
                case "A13":
                case "A14":
                case "A17":
                case "C1":
                    Type a12Type = typeof(Gerneric1);
                    PropertyInfo a12PropInfo = a12Type.GetProperty(subNo);

                    string a12Ans = (answerObj != null && a12PropInfo.GetValue(answerObj, null) != null)
                                    ? Convert.ToInt32(a12PropInfo.GetValue(answerObj, null)).ToString() : null;

                    SurveyTitleMapping surveyTitleMappingA12 = answerNameList.FirstOrDefault(x => x.Answer == a12Ans);

                    answer = surveyTitleMappingA12 != null ? surveyTitleMappingA12.AnswerName : "無";
                    break;

                case "A20":
                case "A22":
                case "C2":
                    Type a20Type = typeof(Gerneric2);
                    PropertyInfo a20PropInfo = a20Type.GetProperty(subNo);

                    string a20Ans = "";
                    if (type == "A20" || type == "C2")
                    {
                        a20Ans = (answerObj != null && a20PropInfo.GetValue(answerObj, null) != null) 
                                 ? Convert.ToInt32(a20PropInfo.GetValue(answerObj, null)).ToString() : null;
                    }
                    if (type == "A22")
                    {
                        a20Ans = (answerObj != null && a20PropInfo.GetValue(answerObj, null) != null) 
                                 ? a20PropInfo.GetValue(answerObj, null).ToString() : null;

                        if (subNo == "Management") //管理職要轉小寫才符合DB SurveyTitleMapping存入的值
                        {
                            a20Ans = a20Ans != null ? a20Ans.ToLower() : null;
                        }
                    }

                    SurveyTitleMapping surveyTitleMappingA20 = answerNameList
                                                     .FirstOrDefault(x => !x.SubNo.Contains("Other")
                                                                        && x.SubNo == subNo
                                                                        && x.Answer == a20Ans);

                    answer = surveyTitleMappingA20 != null ? surveyTitleMappingA20.AnswerName : "無";
                    break;

                case "B1":
                    Type b1Type = typeof(Occasion);
                    PropertyInfo b1PropInfo = b1Type.GetProperty(subNo);

                    string b1Ans = (answerObj != null && b1PropInfo.GetValue(answerObj, null) != null)
                                    ? b1PropInfo.GetValue(answerObj, null).ToString() : null;

                    SurveyTitleMapping surveyTitleMappingB1 = answerNameList.FirstOrDefault(x => x.Answer == b1Ans);

                    if (subNo == "Other") //其它
                    {
                        surveyTitleMappingB1 = answerNameList.FirstOrDefault(x => x.SubNo == subNo && x.Answer == "content");
                    }

                    answer = (surveyTitleMappingB1 != null && !string.IsNullOrEmpty(surveyTitleMappingB1.AnswerName))
                             ? surveyTitleMappingB1.AnswerName : "無";
                    break;

                case "B2":
                    Type b2Type = typeof(BoxItems);
                    PropertyInfo b2PropInfo = b2Type.GetProperty(subNo);

                    List<int> ansB2List = (answerObj != null && b2PropInfo.GetValue(answerObj, null) != null)
                                        ? b2PropInfo.GetValue(answerObj, null) as List<int> : null;

                    List<string> ansNameB2List = null;
                    if (ansB2List != null)
                    {
                        ansNameB2List = new List<string>();
                        foreach (int ans in ansB2List)
                        {
                            SurveyTitleMapping surveyTitleMappingB2 = answerNameList.FirstOrDefault(x => x.Answer == ans.ToString());

                            ansNameB2List.Add(surveyTitleMappingB2.AnswerName);
                        }
                    }
                    answer = ansNameB2List != null ? string.Join(",", ansNameB2List.ToArray()) : "無";
                    break;
            }

            return answer;
        }
    }
}
