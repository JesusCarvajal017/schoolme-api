namespace Entity.Dtos.Especific.Security
{
    public class ChangePassword
    {
        public int IdUser { get; set; }
        public string PasswordNew { get; set; }
        public string PasswordConfirm { get; set; }
    }
}
