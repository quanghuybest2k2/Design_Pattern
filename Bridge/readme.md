## Bridge cho phép tách rời abstraction (sự trừu tượng) và implementation (thực hiện) của một đối tượng. 
Được sử dụng khi có sự phụ thuộc giữa hai hệ thống có thể thay đổi độc lập và muốn tránh việc gắn kết chặt chẽ giữa chúng.

## thực tế

Hệ thống đa ngôn ngữ: Khi phát triển một ứng dụng hỗ trợ đa ngôn ngữ
Bridge pattern có thể được sử dụng để tách rời giao diện ngôn ngữ (abstraction) và 
các bộ dịch ngôn ngữ cụ thể (implementation). 
Điều này cho phép dễ dàng thêm hoặc thay đổi ngôn ngữ mà không ảnh hưởng đến giao diện.