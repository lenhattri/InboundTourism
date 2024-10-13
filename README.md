﻿# Về Dự án

- Đây là một dự án xây dựng ứng dụng Winform .NET về quản lý tuyến du lịch với kiến trúc dựa trên mô hình 3 lớp với ASP.NET Core API và Entify Core Framework


# Về công nghệ

- Winform .NET GUI
- ASP.NET Core API
- Entity Framework 
- 
# Về cấu trúc

- Core : Xác định các cấu trúc(khung) của các Thực thể(Từ đây gọi là Entity)
- DAL(Data Acccess Layer): Tầng này có nhiệm vụ ánh xạ các Entity trên SQL Server và có nhiệm vụ cung cấp phương thức kết nối thẳng tới Database
- BLL(Bussiness Logic Layer): Tầng Business Logic chịu trách nhiệm thực thi các quy tắc nghiệp vụ cốt lõi, xử lý và quản lý dữ liệu từ giao diện người dùng, đảm bảo tính toàn vẹn và logic của hệ thống. Nó đóng vai trò trung gian giữa tầng giao diện và tầng truy xuất dữ liệu, quản lý các quy trình như tính toán, kiểm tra tính hợp lệ, và điều phối luồng công việc.
- Base: Tầng này cung cấp các lớp config thay thế các lớp mặc định của C#(như HttpClient)
- Views(Presentation layer): Tầng này cung cấp các giao diện UI(Ở đây là Winform)
- API: Dùng các Service ở tầng BLL để quản lý data qua Endpoint: 127.0.0.1:5173/api/v1/
