namespace MoeSto.Web.Models.DtoObjects
{
    public class YPointProperties
    {
        public string balloonContent { get; set; } 
        public string clusterCaption { get; set; } 
        public string hintContent { get; set; } 

        public YPointProperties()
        {
            balloonContent= ""; 
            clusterCaption= "";
            hintContent = "";
        }
    }
}
