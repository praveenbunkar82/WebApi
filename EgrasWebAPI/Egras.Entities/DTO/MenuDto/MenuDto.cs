namespace Egras.Entities.DTO
{
    public class MenuDto
    {
        public int MenuId { get; set; }
        public string MenuDesc { get; set; }
        public string NavigationUrl { get; set; }
        public string MenuParentId { get; set; }
        public string MenuSecured { get; set; }
        public string MenuVisible { get; set; }
    }
}
