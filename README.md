# BoxAdmin

EF Core CLI

orangebear : 

dotnet ef dbcontext scaffold "Server=stagingserver;Database=orangebear;user id=orangebear;password=RxLGHgR*Earz;Connection Timeout=300;" "Microsoft.EntityFrameworkCore.SqlServer" -o "Orangebear\Models" -f -c "orangebearContext" --context-dir "Orangebear\Context" --use-database-names

kw : 

dotnet ef dbcontext scaffold "Server=stagingserver;Database=kw;user id=orangebear;password=RxLGHgR*Earz;Connection Timeout=300;" "Microsoft.EntityFrameworkCore.SqlServer" -o "Kw" -f -c "kwContext" --context-dir "Kw\Context"

box : 

dotnet ef dbcontext scaffold "Server=stagingserver;Database=BOX;user id=orangebear;password=RxLGHgR*Earz;Connection Timeout=300;" "Microsoft.EntityFrameworkCore.SqlServer" -o "Entities\BoxContext" -f -c "BoxContext" --context-dir "Contexts"