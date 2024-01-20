using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarhangbookStore.DataModel.Entities
{
    public class TBL_SiteSetting
    {
        [Key]
        public int SiteSettingId { get; set; }

        [DisplayName("نام سایت")]
        [MaxLength(256, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string SiteName { get; set; }

        [DisplayName("توضیحات وب سایت")]
        [DataType(DataType.MultilineText)]
        public string SiteDescription { get; set; }

        [DisplayName("کلمات کلیدی")]
        [DataType(DataType.MultilineText)]
        public string SiteKeywordsKey { get; set; }

        [DisplayName("API")]
        [MaxLength(256, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string SmsApi { get; set; }

        [DisplayName("شماره فرستنده")]
        [MaxLength(15, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string SmsSender { get; set; }

        [DisplayName("ایمیل فرستنده")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string MailAddress { get; set; }

        [DisplayName("کلمه عبور ایمیل")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string MailPassword { get; set; }
    }
}
