# MyZooEmulator
Giả lập môi trường sở thú bằng Console App DOTNET bao gồm các loài:

| Name     | Heath | Type    | Weight |
| ---      | ---   | ---     | ---    |
| Fox      | 3     | Animal  | 5      |
| Rabbit   | 3     | Animal  | 3      |
| Tiger    | 4     | Animal  | 150    |
| Wolf     | 4     | Animal  | 70     |
| Lion     | 5     | Animal  | 160    |
| Bear     | 6     | Animal  | 450    |
| Elenphant| 7     | Animal  | 5000   |


Môi trường của sở thú:

| Method           |                                                               Feature                                                                                       |
| ---              | ---                                                                                                                                                         |
| SetWatchPeriod() | Đặt thời gian trong giả lập = một ngày, VD: set 5000ms = 1day                                                                                               |
| WatchFor()       | Thời gian tăng dần                                                                                                                                          |
| RandomWeather()  | Thời tiết thay đổi mỗi ngày                                                                                                                                 |
| TouchSomebody()  | Mỗi ngày sẽ có ngẫu nhiên 1 sinh vật đánh nhau và giảm trạng thái, nếu trong sở thú có sinh vật nào có trạng thái Sick thì health giảm 1, cân nặng giảm 10% |


Thao tác của người chơi:

| Name                     | Feature                                                |
| ---                      | ---                                                  |
| Thêm sinh vật            | Thêm bất kì giống loài nào vào sở thú                |
| Cho sinh vật ăn          | Chọn bất kì sinh vật nào cho ăn                      |
| Chữa bệnh cho sinh vật   | Chữa cho bất kì sinh vật nào đang có trạng thái Sick |
| Xóa sinh vật khỏi sở thú | Xóa 1 sinh vật khỏi sở thú                           |
| Thông tin các sinh vật   | Nhiều chức năng để xem thông tin trong sở thú        |
