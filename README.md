# **Progres Proyek**

Melakukan pengembangan dari konsep pekan sebelumnya. Pada pekan ini, kelompok 10 membuat fondasi console-Line program. Yang terdiri atas;

* **BattleSystem** : Sistem dasar pertarungan. Dimana menginisiasikan battle, memilih jenis serangan, dan mengambil informasi dari IAttackStrategy untuk mengkalkulasi serangan, dan kekalahan (baik dari sisi player, ataupun musuh).
* **Character** : Informasi dasar karakter seperti health dan attack. Dipastikan menggunakan singleton sehingga hanya ada satu instance pemain dalam setiap level. Menghitung penambahan base information ketika level up, dan men-track money.
* **EnemyFactory** : Menyimpan informasi mengenai musuh (Tuyul, Pocong, dan Kecoak), dimana setiap karakter memiliki karakteristik sendiri dan special attack style. EnemyFactory menyimpan perhitungan mengenai jenis attack yang digunakan dan special skill setiap musuh. Lantas, musuh akan dikeluarkan berdasar level.
* **IAttackStrategy** : Attack player terbagi menjadi dua di sini, yakni short range, dan long range, dimana long range memiliki attack lebih tinggi dibanding short range. Berdasar serangan yang dipilih, perhitungan health musuh akan dilakukan.
* **Item** : Inventory untuk menyimpan uang dan health potion
