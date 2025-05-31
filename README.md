# Dự án

- Đây là một dự án xây dựng ứng dụng Winform .NET về quản lý tuyến du lịch với kiến trúc dựa trên mô hình 3 lớp kết hợp RESTful API. Sử dụng ASP.NET Core và ADO.NET

# Công nghệ

- Winform .NET Core
- ASP.NET Core API
- Entity Framework Core
- ASP.NET Core MVC

 # Các tầng
- Core : Xác định các cấu trúc(khung) của các Thực thể(Từ đây gọi là Entity)
- DAL(Data Acccess Layer): Tầng này có có nhiệm vụ cung cấp phương thức kết nối thẳng tới Database
- BLL(Bussiness Logic Layer): Tầng này chịu trách nhiệm thực thi các quy tắc nghiệp vụ cốt lõi, xử lý và quản lý dữ liệu từ giao diện người dùng, đảm bảo tính toàn vẹn và logic của hệ thống. Đóng vai trò trung gian giữa tầng giao diện(Views) và tầng truy xuất dữ liệu(DAL), quản lý các quy trình như tính toán, kiểm tra tính hợp lệ, và điều phối luồng công việc.
- Base: Tầng này cung cấp các lớp về các tính năng logic và các lớp config thay thế các lớp mặc định của C#(như HttpClient)
- Views(Presentation layer): Tầng này cung cấp các giao diện UI(Ở đây là Winform)
- API: Dùng các Service ở tầng BLL để quản lý data qua Endpoint: 127.0.0.1:5173/api/v1/
- Web: Dùng để hiển thị giao diện người dùng dạng website theo mô hình MVC

# Sơ đồ hệ thống 

![Sơ đồ hệ thống](https://github.com/lenhattri/InboundTourism/blob/master/Sodo.png)

