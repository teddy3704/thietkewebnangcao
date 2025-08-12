# EF Lab 1 — FULL (.NET 9 + EF Core 9, VS Code)

## Câu 1 — Code First
Thư mục: `Q1_CodeFirst_NET9`
Lệnh:
```
dotnet restore
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet run
```

## Câu 2 & 4 — Database First (Scaffold)
Thư mục: `Q2_Q4_DbFirst_Scaffold_NET9`
Quy trình chuẩn:
1. Chạy `Step1_CreateBlogsPosts.sql` để tạo DB & 2 bảng.
2. Scaffold lần 1:
```
dotnet ef dbcontext scaffold "Server=(localdb)\MSSQLLocalDB;Database=BloggingDb9_Scaffold;Trusted_Connection=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer --context BloggingDbContext --output-dir Scaffolding --force
```
3. Chạy `Step2_AddStudent.sql` để thêm bảng Student.
4. Scaffold lần 2 (sẽ xuất hiện entity Student).
5. (Tùy chọn) Chạy `dotnet run` với mã mẫu trong repo để kiểm tra CRUD đọc dữ liệu.

## Câu 3 — Model First (EF Core style)
Thư mục: `Q3_ModelFirst_NET9`
Lệnh:
```
dotnet restore
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialModelFirst
dotnet ef database update
dotnet run
```

### Ghi chú
- Mặc định dùng SQL Server LocalDB `(localdb)\MSSQLLocalDB`. Nếu khác, sửa chuỗi kết nối trong `appsettings.json` (Q1 & Q3) hoặc trong `BloggingDbContext.OnConfiguring` (Q2&4).
- Nếu gặp lỗi file bị khoá khi build: dừng tiến trình đang chạy, `dotnet clean` rồi `dotnet build`.
- Nếu migration trùng tên: dùng `dotnet ef migrations list` xem danh sách; tạo tên khác hoặc `database drop` + `migrations remove` rồi làm lại.
