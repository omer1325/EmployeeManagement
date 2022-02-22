namespace EmployeeManagement.Common.ConstantModels
{
    public static class Constant
    {
        #region EmployeeLeaveType
        public const string RecordsFound = "Kayıtlar Bulundu";
        public const string RecordFound = "Kayıt Bulundu";
        public const string RecordNotFound = "Kayıt Bulunamadı";
        public const string RecordCreateSuccessfully = "Kayıt Başarıyla Gerçekleşti";
        public const string RecordCreateNotSuccessfully = "Kayıt Oluşturulurken Hata Oluştu";
        public const string RecordUpdateSuccessfully = "Kayıt Başarıyla Güncellendi";
        public const string RecordUpdateNotSuccessfully = "Kayıt Güncellenirken Hata Oluştu";
        public const string RecordDeleteSuccessfully = "Kayıt Başarıyla Silindi";
        public const string RecordDeleteNotSuccessfully = "Kayıt Silinirken Hata Oluştu";
        public const string RecordDeleteNotBeEmpty = "Silmek için kayıt seçiniz";
        public const string RecordCreateNotBeEmpty = "Parametre Olarak Girilen Data Boş Olamaz";
        #endregion

        #region EmployeeAccountLogin
        public const string EmailOrPassworndWrong = "Email adresiniz veya şifreniz yanlıştır";
        public const string DoesNotHaveEmail = "Bu email adresine ait kayıtlı kullanıcı bulunamamıştır";
        public const string OccurredAnError = "Bir hata meydana geldi. Lütfen daha sonra tekrar deneyiniz";
        #endregion

        #region EmployeeAcccuntSignup
        public const string PasswordNotContainUserName = "Şifre Alanı Kullanıcı Adı İçeremez";
        public const string PasswordNotContainEmail = "Şifre Alanı Email Adresinizi İçeremez";
        public const string PasswordNotContain1234 = "Şifre Alanı Ardaşık Sayı İçeremez";
        public const string PasswordRequiresUpper = "Şifrenizde En Az 1 Büyük Harf Bulunmalıdır";
        public const string PasswordRequiresLower = "Şifrenizde En Az 1 Küçük Harf Bulunmalıdır";
        public const string PasswordRequiresNonAlphanumeric = "Şifrenizde En Az 1 Özel Karakter Harf Bulunmalıdır";
        public const string PasswordRequiresDigit = "Şifrenizde En Az 1 Rakam Bulunmalıdır ('0'-'9')";
        public const string UserNameCanNotStartDigit = "Kullanıcı Adının İlk Karakteri Rakam İçeremez";
        #endregion

        #region SeedRole
        public const string Admin_Role = "Administrator";
        public const string Employee_Role = "Employee";
        #endregion

        #region SeedUser
        public const string Admin_Name = "Admin";
        public const string Admin_Email = "omer.ingec24@gmail.com";
        public const string Admin_Password = "Test123.";
        #endregion

        #region EmployeeEdit
        public const string PhoneNumberAlreadyExist = "Bu telefon numarası başka üye tarafından kullanılmaktadır";
        public const string OldPasswordWrong = "Eski şifreniz yanlış";
        #endregion

        #region Session
        public const string LoginUserInfo = "Giriş Yapan Kullanıcı Bilgisi";
        #endregion

    }
}
