using AutoMapper;
using GST_API_Library.Models.GSTR3B;
using GST_API_DAL.Models;

public class Gstr3BMappingProfile : Profile
{
    public Gstr3BMappingProfile()
    {
        CreateMap<GetGSTR3BDetails, Gstr3BDetails>();
        CreateMap<GST_API_Library.Models.GSTR3B.SupDetails44, GST_API_DAL.Models.SupDetails44>();
        CreateMap<GST_API_Library.Models.GSTR3B.OsupDet44, GST_API_DAL.Models.OsupDet44>();
        CreateMap<GST_API_Library.Models.GSTR3B.OsupZero44, GST_API_DAL.Models.OsupZero44>();
        CreateMap<GST_API_Library.Models.GSTR3B.OsupNilExmp44, GST_API_DAL.Models.OsupNilExmp44>();
        CreateMap<GST_API_Library.Models.GSTR3B.IsupRev44, GST_API_DAL.Models.IsupRev44>();
        CreateMap<GST_API_Library.Models.GSTR3B.OsupNongst44, GST_API_DAL.Models.OsupNongst44>();
        CreateMap<GST_API_Library.Models.GSTR3B.InterSup44, GST_API_DAL.Models.InterSup44>();
        CreateMap<GST_API_Library.Models.GSTR3B.UnregDetail44, GST_API_DAL.Models.UnregDetail44>();
        CreateMap<GST_API_Library.Models.GSTR3B.CompDetail44, GST_API_DAL.Models.CompDetail44>();
        CreateMap<GST_API_Library.Models.GSTR3B.UinDetail44, GST_API_DAL.Models.UinDetail44>();
        CreateMap<GST_API_Library.Models.GSTR3B.EcoDtls44, GST_API_DAL.Models.EcoDtls44>();
        CreateMap<GST_API_Library.Models.GSTR3B.EcoSup44, GST_API_DAL.Models.EcoSup44>();
        CreateMap<GST_API_Library.Models.GSTR3B.EcoRegSup44, GST_API_DAL.Models.EcoRegSup44>();
        CreateMap<GST_API_Library.Models.GSTR3B.ItcElg44, GST_API_DAL.Models.ItcElg44>();
        CreateMap<GST_API_Library.Models.GSTR3B.ItcAvl44, GST_API_DAL.Models.ItcAvl44>();
        CreateMap<GST_API_Library.Models.GSTR3B.ItcRev44, GST_API_DAL.Models.ItcRev44>();
        CreateMap<GST_API_Library.Models.GSTR3B.ItcNet44, GST_API_DAL.Models.ItcNet44>();
        CreateMap<GST_API_Library.Models.GSTR3B.ItcInelg44, GST_API_DAL.Models.ItcInelg44>();
        CreateMap<GST_API_Library.Models.GSTR3B.InwardSup44, GST_API_DAL.Models.InwardSup44>();
        CreateMap<GST_API_Library.Models.GSTR3B.IsupDetail44, GST_API_DAL.Models.IsupDetail44>();
        CreateMap<GST_API_Library.Models.GSTR3B.TxPmt44, GST_API_DAL.Models.TxPmt44>();
        CreateMap<GST_API_Library.Models.GSTR3B.TxPy44, GST_API_DAL.Models.TxPy44>();
        CreateMap<GST_API_Library.Models.GSTR3B.Adjnegliab44, GST_API_DAL.Models.Adjnegliab44>();
        CreateMap<GST_API_Library.Models.GSTR3B.Nettaxpay44, GST_API_DAL.Models.Nettaxpay44>();
        CreateMap<GST_API_Library.Models.GSTR3B.Pdcash44, GST_API_DAL.Models.Pdcash44>();
        CreateMap<GST_API_Library.Models.GSTR3B.Pditc44, GST_API_DAL.Models.Pditc44>();
        CreateMap<GST_API_Library.Models.GSTR3B.Pdnl44, GST_API_DAL.Models.Pdnl44>();
        CreateMap<GST_API_Library.Models.GSTR3B.IntrLtfee44, GST_API_DAL.Models.IntrLtfee44>();
        CreateMap<GST_API_Library.Models.GSTR3B.IntrDetails44, GST_API_DAL.Models.IntrDetails44>();
        CreateMap<GST_API_Library.Models.GSTR3B.LtfeeDetails44, GST_API_DAL.Models.LtfeeDetails44>();
        CreateMap<GST_API_Library.Models.GSTR3B.LiabBreakup44, GST_API_DAL.Models.LiabBreakup44>();
        CreateMap<GST_API_Library.Models.GSTR3B.Liability44, GST_API_DAL.Models.Liability44>();
    }
}