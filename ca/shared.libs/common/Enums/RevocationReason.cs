using System.ComponentModel.DataAnnotations;

namespace GET.PKI.Common
{
    public enum RevocationReason
    {
        [Display(Name = "Unspecified")]
        Unspecified = 0,
        [Display(Name = "Key Compromise")]
        KeyCompromise = 1,
        [Display(Name = "CA Compromise")]
        CACompromise = 2,
        [Display(Name = "Affiliation Changed")]
        AffiliationChanged = 3,
        [Display(Name = "Superseded")]
        Superseded = 4,
        [Display(Name = "Cessation Of Operation")]
        CessationOfOperation = 5,
        [Display(Name = "Certificate Hold")]
        CertificateHold = 6,
        [Display(Name = "Remove From Crl")]
        RemoveFromCrl = 8,
        [Display(Name = "Privilege Withdrawn")]
        PrivilegeWithdrawn = 9,
        [Display(Name = "AA Compromise")]
        AACompromise = 10
    }
}