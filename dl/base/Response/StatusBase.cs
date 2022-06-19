using System.ComponentModel;

namespace GET.Spooler.Base
{
    public enum StatusCode
    {

        SUCCESS = 0,

        EXCEPTION_THROWN = 9000,

        [Description("")]
        BUSINESS_ERROR = 9200,


        [Description("The Transaction Not Saved on DATABASE")]
        NOT_SAVED,


        [Description("There Is Another Printer With This Serial Number")]
        ADD_TWO_PRINTERS_WITH_SAME_SERIAL_NUMBER,

        [Description("There Is Another Printer With This IP Address")]
        ADD_TWO_PRINTERS_WITH_SAME_IP_ADDRESS,


        [Description("There is another printing machine with this URL")]
        ADD_TWO_PRINTING_MACHINE_WITH_SAME_MACHINE_URL,


        [Description("Cannot find printer with this name")]
        CANNOT_FIND_PRINTER_WITH_THIS_NAME,


        [Description("There Is Another Feature With This Feature Name")]
        ADD_TWO_FEATURE_WITH_SAME_FEATURE_NAME,

        [Description("There is another printer with this type and name")]
        ADD_TWO_PRINTER_TYPE_WITH_SAME_PRINTERTYPE_NAME,


        [Description("There is another site with this name")]
        ADD_TWO_SITE_WITH_SAME_NAME,


        [Description("Cannot find site with this name")]
        CANNOT_FIND_SITE_WITH_THIS_NAME,


        [Description("Cannot delete this site because there are printing stations inside it")]
        CANNOT_DELETE_SITE_WITH_PRINTINGMACHINES_INSIDE_IT,



        [Description("There is another document type with this name")]
        ADD_TWO_DOCUMENTTYPE_WITH_SAME_NAME,



        [Description("Cannot delete this document type because there are printer feeders related to it")]
        CANNOT_DELETE_DOCUMENT_TYPE_WITH_PRINTER_FEEDERS_INSIDE_IT,


        [Description("There is another configuration with this passport type method")]
        ADD_TWO_CONFIGURATIONS_WITH_SAME_GettingPassportTypeMethod,


        [Description("There is another Device with this name")]
        ADD_TWO_Device_WITH_SAME_NAME,


        [Description("There is another Profile with this name")]
        ADD_TWO_Profile_WITH_SAME_NAME,


        [Description("There is another Property with this name")]
        ADD_TWO_Property_WITH_SAME_NAME,


        [Description("")]
        TIME_OUT = 9500,
        UNEXPECTED = 9501,


        [Description("eP600 service controller is down")]
        CONTROLLER_SERVICE_IS_DOWN = 9502,


        [Description("License not exists")]
        LICENSE_NOT_EXISTS = -100,

        [Description("Object not found")]
        OBJECT_NOT_FOUND = -3332,

        [Description("Service Paused")]
        SERVICE_PAUSED,

        [Description("Job GUID already exists")]
        JOB_GUID_ALREADY_EXISTS,
        NO_ASSIGNED_PRINTER,
        [Description("Deducted Already")]
        DEDUCTED_ALREADY = -101, 
        [Description("Job Ref NO already exists")]
        JOB_REF_NO_ALREADY_EXISTS = 1204,

        [Description("No CVCA ADDED OR UPDATED")]
        No_CVCA_ADDED_OR_UPDATED = 1205,
    }
}