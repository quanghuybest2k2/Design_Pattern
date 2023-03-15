Tạo một lớp Game abstract. Lớp này có một phương thức Play là phương thức mẫu, định nghĩa trọng tâm của thuật toán cho trò chơi. Phương thức Play gọi các phương thức Initialize, StartPlay và EndPlay. Tuy nhiên, chúng ta chỉ định nghĩa một cách tổng quát cho các phương thức này trong lớp Game abstract, và để cho các lớp con tùy chỉnh các bước chi tiết.

Sau đó, tạo hai lớp con là Cricket và Football, mỗi lớp con cụ thể hóa các phương thức Initialize, StartPlay và EndPlay cho trò chơi tương ứng.

Cuối cùng, trong phương thức Main, tạo một đối tượng game từ lớp Cricket và gọi phương thức Play để chơi trò chơi. Các bước cụ thể của trò chơi sẽ được xác định bởi lớp Cricket con.