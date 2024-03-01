using System.ComponentModel.DataAnnotations;

namespace SampleApiBackend.Models
{
    public enum ScentType
    {
        [Display(Name = "Rozmaring")]
        Rozmaring,

        [Display(Name = "Narancsvirág")]
        Narancs,

        [Display(Name = "Citromfű")]
        Citrom,

        [Display(Name = "Eukaliptusz")]
        Eukaliptusz,

        [Display(Name = "Mandula és méz")]
        Mandula,

        [Display(Name = "Szantálfa")]
        Szantal,

        [Display(Name = "Fenyő")]
        Fenyo,

        [Display(Name = "Rózsa")]
        Rozsa,

        [Display(Name = "Áfonya")]
        Afonya,

        [Display(Name = "Kávé")]
        Kave,

        [Display(Name = "Kókusz")]
        Kokusz,

        [Display(Name = "Gyömbér")]
        Gyomberlime,

        [Display(Name = "Fahéj")]
        Fahej,

        [Display(Name = "Levendula")]
        Levendula,

        [Display(Name = "Vanília")]
        Vanilia,

        [Display(Name = "Fűszernövények")]
        Fuszeres,

        [Display(Name = "Bergamott")]
        Bergamott,

        [Display(Name = "Mézeskalács")]
        Mezeskalacs,

        [Display(Name = "Kamilla")]
        Kamilla,

        [Display(Name = "Zöld sárkány")]
        Lime

    }
}