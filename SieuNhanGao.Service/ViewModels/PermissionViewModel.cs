namespace SieuNhanGao.Service.ViewModels
{
    public class PermissionViewModel
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public bool IsGranted { get; set; }
    }
}