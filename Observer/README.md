# Observer là gì?

Observer là một mẫu thiết kế hành vi (behavioral design pattern) cho phép các đối tượng (objects) được 
thông báo về các thay đổi của một đối tượng khác mà chúng quan tâm. Mô hình này thiết kế một cơ chế 
một-đa để thông báo cho các đối tượng đăng ký (subscribers) về sự thay đổi trong đối tượng được quan sát (subject).

Observer bao gồm các thành phần:

Subject (đối tượng quan sát): Đây là đối tượng mà các đối tượng Observer quan tâm để theo dõi thay đổi. 
Subject cung cấp một giao diện để đăng ký và hủy đăng ký Observer, cũng như thông báo cho các Observer khi có thay đổi.
Observer (người quan sát): Đây là các đối tượng quan tâm đến thay đổi trong Subject. 
Observer đăng ký với Subject và nhận được thông báo khi có thay đổi xảy ra.
Thay đổi (change): Đây là thông tin về sự thay đổi trong Subject mà các Observer quan tâm. Thông tin này được chuyển 
đến các Observer thông qua phương thức thông báo từ Subject.
Observer cho phép các đối tượng Observer quan sát một đối tượng Subject mà không cần biết chi tiết về nó. Điều này giúp 
tách rời sự tương tác giữa các đối tượng, tăng tính mở rộng và tái sử dụng trong thiết kế phần mềm. Khi một thay đổi xảy ra 
trong Subject, tất cả các Observer đăng ký sẽ nhận được thông báo tương ứng và có thể thực hiện hành động phù hợp với thay đổi đó.

Một ví dụ phổ biến về mô hình Observer là sử dụng trong giao diện người dùng (UI) của các ứng dụng. Ví dụ, 
trong mô hình Model-View-Controller (MVC), View (giao diện người dùng) đăng ký như là một Observer với Model (dữ liệu) để 
nhận thông báo khi dữ liệu thay đổi. Khi dữ liệu thay đổi, View cập nhật hiển thị tương ứng để phản ánh các thay đổi đó.

Tóm lại, Observer cho phép các đối tượng quan tâm đến sự thay đổi trong một đối tượng khác nhận được thông báo 
và phản ứng tương ứng. Điều này giúp xây dựng các hệ thống linh hoạt, dễ mở rộng và giảm sự phụ thuộc chặt chẽ
# Observer áp dụng trong thực tế:

## Giao diện người dùng (UI):

Observer thường được sử dụng trong các framework và thư viện phát triển giao diện người dùng.
View (giao diện người dùng) đăng ký như là một Observer với Model (dữ liệu) để nhận thông báo khi dữ liệu thay đổi.
Khi dữ liệu thay đổi, View sẽ cập nhật hiển thị tương ứng để phản ánh các thay đổi đó.
## Hệ thống sự kiện (event-driven systems):

Trong hệ thống sự kiện, mô hình Observer được sử dụng để xử lý các sự kiện và 
thông báo cho các thành phần quan tâm. Các thành phần quan tâm (Observer) đăng ký để
lắng nghe sự kiện và khi sự kiện xảy ra, các Observer sẽ được thông báo và thực hiện hành động tương ứng.

