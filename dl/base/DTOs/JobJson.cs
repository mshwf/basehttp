using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace GET.Spooler.Base
{
    public class PageDto
    {

        public int BlackImageId { get; set; }
        public int ColorImageId { get; set; }
        public int UVImageId { get; set; }
        public byte[] BlackImage { get; set; }
        public byte[] ColorImage { get; set; }
        public byte[] UVImage { get; set; }

        public XElement ToXML()
        {
            var xml = new XElement("images",
                 new XElement("black_image", new XAttribute("job_file_id", BlackImageId.ToString())),
                 new XElement("color_image", new XAttribute("job_file_id", ColorImageId.ToString())),
                 new XElement("uv_image", new XAttribute("job_file_id", UVImageId.ToString())));
            return xml;
        }
        public static PageDto FromXML(XElement xml)
        {
            var page = new PageDto();
            var xImages = xml.Element("images");

            try
            {
                page.BlackImageId = Convert.ToInt32(xImages.Element("black_image").Attribute("job_file_id").Value);
                page.ColorImageId = Convert.ToInt32(xImages.Element("color_image").Attribute("job_file_id").Value);
                page.UVImageId = Convert.ToInt32(xImages.Element("uv_image").Attribute("job_file_id").Value);


            }
            catch (Exception ex)
            {
            }
            return page;

        }
    }

    public class FeatureDto
    {
        public int FeatureID { get; set; }
        public string FeatureName { get; set; }
        public string FeatureDescription { get; set; }
        public string FeatureValue { get; set; }
    }


    public class PrintOptionsDto
    {
        public int PrintOptionsId { get; set; }
        public bool IsContactEncoding { get; set; }
        public bool IsContactlessEncoding { get; set; }
        public bool IsMagneticRead { get; set; }

        public List<FeatureDto> JobFeatures { get; set; } = new List<FeatureDto>();

        internal XElement ToXML()
        {
            var xml = new XElement("print_options",
                 new XAttribute("contact_encoding", IsContactEncoding.ToString()),
                 new XAttribute("contactless_encoding", IsContactlessEncoding.ToString()),
                 new XAttribute("magnetic_read", IsMagneticRead.ToString()));
            //foreach (var feature in JobFeatures)
            //{
            //    xml.Add(new XAttribute(feature.FeatureName, feature.FeatureValue));
            //}

            return xml;
        }
        //internal static PrintOptionsDto FromXML(XElement xml)
        //{
        //    var printOptions = new PrintOptionsDto();
        //    var contactEncodingAttribute = xml.Attribute("contact_encoding");
        //    var contactlessEncodingAttribute = xml.Attribute("contactless_encoding");
        //    var magneticReadAttribute = xml.Attribute("magnetic_read");

        //    if (contactEncodingAttribute != null) printOptions.IsContactEncoding = Convert.ToBoolean(contactEncodingAttribute.Value);
        //    if (contactlessEncodingAttribute != null) printOptions.IsContactlessEncoding = Convert.ToBoolean(contactlessEncodingAttribute.Value);
        //    if (magneticReadAttribute != null) printOptions.IsMagneticRead = Convert.ToBoolean(magneticReadAttribute.Value);

        //    foreach (var attribute in xml.Attributes())
        //    {
        //        var attributeName = attribute.Name.LocalName;
        //        if (attributeName != "contact_encoding" &&
        //            attributeName != "contactless_encoding" &&
        //            attributeName != "magnetic_read")
        //            printOptions.JobFeatures.Add(new FeatureDto { FeatureName = attributeName, FeatureValue = attribute.Value });
        //    }
        //    return printOptions;
        //}
    }

    public class PrintingOrderDto
    {
        public List<PageDto> pages { get; set; } = new List<PageDto>();
        public PrintOptionsDto print_options { get; set; } = new PrintOptionsDto();
        public Dictionary<string, string> definition { get; set; } = new Dictionary<string, string>();
    }
}
