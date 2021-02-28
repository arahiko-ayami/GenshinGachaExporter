# Genshin Gacha Exporter

##Cách sử dụng

Cách sử dụng rất đơn giản:
1. Bạn phải sử dụng PC
2. Mở game lên, mở trang lịch sử roll gacha
3. Tắt game đi
4. Chạy cái app này
5. Sau khi chạy xong thì vào thư mục "excel_files" trong đó có các file excel chứa lịch sử roll của bạn
6. Lên cho tôi phản hồi nó có chạy tốt hay không?

## FAQs

Q: App này có phải open-source không?

A: Có, vì tôi sẽ share link github ngay dưới này



Q: App này được viết bằng ngôn ngữ gì?

A: C#, chạy trên .NET Framework 4.7.2



Q: Đây có phải phần mềm thứ 3 không?

A: Đây là một phần mềm thứ 3, đương nhiên rồi, bất cứ thứ gì không phải do sự tương tác giữa bạn (bên thứ 2) và nhà phát hành (bên thứ 1) thì đều là bên thứ 3. Quan trọng là cách nó tác động vào game như thế nào. Phần mềm của tôi viết ra chỉ đọc một file duy nhất, giống như cách bạn mở file đó bằng notepad để đọc, file tôi dùng cũng chính là file mà một anh bạn nào đó trên group này chia sẻ cách đọc lịch sử roll trên Chrome. Như bạn thấy đấy, nó đọc mỗi file game, còn lại chả làm gì khác



Q: Cách app này vận hành như thế nào? Nó có gây hại cho máy tính tôi không?

A: App của tôi sẽ đọc một file log trong game, lấy thông tin từ đó và sử dụng thông tin đó để tương tác với API của chính miHoYo, API này chính là API cung cấp thông tin lịch sử roll cho trang lịch sử roll trong game của bạn. Sau khi có được thông tin, nó trích xuất thông tin này dưới 2 định dạng .json và .xlsx (File Excel) để người dùng sử dụng. Trong quá trình này, toàn bộ thông tin chỉ nằm trên máy của bạn, nếu bạn không tin, bạn có thể xem source code ở trang github tôi để bên dưới



Q: App này liệu có làm tôi bị ban bởi anti-cheat trong game?

A: Trừ khi anti-cheat là phần mềm gián điệp theo dõi máy tính bạn thì may ra, còn thực tế là bạn phải tắt game đi thì app mới có thể đọc được file (cơ chế của máy tính là như thế để đảm bảo không có tranh chấp tài nguyên giữa 2 hay nhiều ứng dụng)
