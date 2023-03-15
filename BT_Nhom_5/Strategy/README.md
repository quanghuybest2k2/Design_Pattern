Strategy pattern là một mẫu thiết kế cho phép chúng ta chuyển đổi giữa các giải thuật hoặc chiến lược khác nhau mà không làm thay đổi các đối tượng sử dụng chúng.

Trong mẫu thiết kế này, chúng ta tạo ra các lớp con cho mỗi chiến lược hoặc giải thuật và gán chúng cho các đối tượng cần sử dụng chúng. Khi cần thay đổi chiến lược hoặc giải thuật, chúng ta chỉ cần thay đổi lớp con được gán cho đối tượng đó.

Ví dụ, nếu chúng ta có một đối tượng hỗ trợ tính toán chi phí gửi hàng với hai chiến lược khác nhau (giao hàng tiêu chuẩn và giao hàng nhanh), chúng ta có thể sử dụng Strategy pattern để tạo ra hai lớp con cho mỗi chiến lược và gán chúng cho đối tượng tính toán chi phí gửi hàng. Khi cần thay đổi chiến lược, chúng ta chỉ cần thay đổi lớp con được gán cho đối tượng.