using Core.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Ürün eklendi";
        public static string CarUpdated = "Ürün güncellendi";
        public static string CarDeleted = "Ürün silindi";
        public static string CarNameInvalid = "Ürin ismi geçersiz";
        public static string MaintenanceTime = "Bakım zamanında";
        public static string CarListed = "Listelendi";

        public static string BrandAdded = "Marka eklendi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string BrandDeleted = "Marka silindi";

        public static string ColorAdded = "Renk eklendi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorDeleted = "Renk silindi";

        public static string BrandListed = "Marka listelendi";
        public static string ColorListed = "Renk listelendi";

        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerUpdated = "Müşteri Güncellendi";
        public static string CustomerDeleted = "Müşteri Silindi";
        public static string CustomerListed = "Müşteri Listelendi";


        public static string RentalAdded = "Araba kiralandı";
        public static string RentalUpdated = "Araba kira işlemi güncellendi";
        public static string RentalListed = "Kira Listelendi";
        public static string RentalInvalid = "Kiralama geçersiz";

        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UserDeleted = "Kullanıcı silindi";

        public static string CarImageAdded = "Resim eklendi.";
        public static string CarImageDeleted = "Resim silindi ";
        public static string CarImageListed = "Resim listelendi";
        public static string CarImageUpdated = "Resim güncellendi";
        public static string CarImageLimitExceeded;
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kayıt oldu.";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError = "Parola Hatası";
        public static string SuccessfulLogin = "Başarılı Giriş";
        public static string UserAlreadyExists = "Kullanıcı Mecvut";
        public static string AccessTokenCreated = "Erişim oluşturuldu.";
        public static string CardDeleted = "Kredi kartı silindi";
    }
}
