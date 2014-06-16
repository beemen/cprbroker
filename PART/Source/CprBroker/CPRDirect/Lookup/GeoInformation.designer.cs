
    using System;
    using System.Collections.Generic;
    using CprBroker.Schemas.Wrappers;

    namespace CprBroker.Providers.CPRDirect
    {
    
    public partial class StreetType: Wrapper
    {
        #region Common
        public override int Length
        {
            get { return 111; }
        }
        #endregion
        
        #region Properties
    
        ///  <summary>
        /// Danish: KOMKOD
        /// The municipality code
        ///  </summary>
        public decimal MunicipalityCode
        {
            get { return this.GetDecimal(4, 4); }

            set { this.SetDecimal(value, 4, 4); }
        }  
        ///  <summary>
        /// Danish: VEJKOD
        /// The street code
        ///  </summary>
        public decimal StreetCode
        {
            get { return this.GetDecimal(8, 4); }

            set { this.SetDecimal(value, 8, 4); }
        }  
        ///  <summary>
        /// Danish: VEJADRNVN
        /// The street name
        ///  </summary>
        public string StreetName
        {
            get { return this.GetString(52, 20); }

            set { this.SetString(value, 52, 20); }
        }  
        #endregion

    }

  
    public partial class CityType: Wrapper
    {
        #region Common
        public override int Length
        {
            get { return 66; }
        }
        #endregion
        
        #region Properties
    
        ///  <summary>
        /// Danish: KOMKOD
        /// The municipality code
        ///  </summary>
        public decimal MunicipalityCode
        {
            get { return this.GetDecimal(4, 4); }

            set { this.SetDecimal(value, 4, 4); }
        }  
        ///  <summary>
        /// Danish: VEJKOD
        /// The street code
        ///  </summary>
        public decimal StreetCode
        {
            get { return this.GetDecimal(8, 4); }

            set { this.SetDecimal(value, 8, 4); }
        }  
        ///  <summary>
        /// Danish: HUSNRFRA
        /// House number from
        ///  </summary>
        public decimal HouseNumberFrom
        {
            get { return this.GetDecimal(12, 4); }

            set { this.SetDecimal(value, 12, 4); }
        }  
        ///  <summary>
        /// Danish: HUSNRTIL
        /// House number to
        ///  </summary>
        public decimal HouseNumberTo
        {
            get { return this.GetDecimal(16, 4); }

            set { this.SetDecimal(value, 16, 4); }
        }  
        ///  <summary>
        /// Danish: LIGEULIGE
        /// Equal or unequal house number
        ///  </summary>
        public char EqualOrUnequal
        {
            get { return this.GetChar(20); }

            set { this.SetChar(value, 20); }
        }  
        ///  <summary>
        /// Danish: TIMESTAMP
        /// Date of report
        ///  </summary>
        public DateTime? Timestamp
        {
            get { return this.GetDateTime(21, 12, "yyyyMMddHHmm"); }

            set { this.SetDateTime(value, 21, 12, "yyyyMMddHHmm"); }
        }  
        ///  <summary>
        /// Danish: BYNVN
        /// City name
        ///  </summary>
        public string CityName
        {
            get { return this.GetString(33, 34); }

            set { this.SetString(value, 33, 34); }
        }  
        #endregion

    }

  
    public partial class AreaRestorationDistrictType: Wrapper
    {
        #region Common
        public override int Length
        {
            get { return 68; }
        }
        #endregion
        
        #region Properties
    
        ///  <summary>
        /// Danish: KOMKOD
        /// The municipality code
        ///  </summary>
        public decimal MunicipalityCode
        {
            get { return this.GetDecimal(4, 4); }

            set { this.SetDecimal(value, 4, 4); }
        }  
        ///  <summary>
        /// Danish: VEJKOD
        /// The street code
        ///  </summary>
        public decimal StreetCode
        {
            get { return this.GetDecimal(8, 4); }

            set { this.SetDecimal(value, 8, 4); }
        }  
        ///  <summary>
        /// Danish: HUSNRFRA
        /// House number from
        ///  </summary>
        public decimal HouseNumberFrom
        {
            get { return this.GetDecimal(12, 4); }

            set { this.SetDecimal(value, 12, 4); }
        }  
        ///  <summary>
        /// Danish: HUSNRTIL
        /// House number to
        ///  </summary>
        public decimal HouseNumberTo
        {
            get { return this.GetDecimal(16, 4); }

            set { this.SetDecimal(value, 16, 4); }
        }  
        ///  <summary>
        /// Danish: LIGEULIGE
        /// Equal or unequal house number
        ///  </summary>
        public char EqualOrUnequal
        {
            get { return this.GetChar(20); }

            set { this.SetChar(value, 20); }
        }  
        ///  <summary>
        /// Danish: TIMESTAMP
        /// Date of report
        ///  </summary>
        public DateTime? Timestamp
        {
            get { return this.GetDateTime(21, 12, "yyyyMMddHHmm"); }

            set { this.SetDateTime(value, 21, 12, "yyyyMMddHHmm"); }
        }  
        ///  <summary>
        /// Danish: BYFORNYKOD
        /// Area restoration code
        ///  </summary>
        public string AreaRestorationCode
        {
            get { return this.GetString(33, 6); }

            set { this.SetString(value, 33, 6); }
        }  
        ///  <summary>
        /// Danish: DISTTXT
        /// District text
        ///  </summary>
        public string DistrictText
        {
            get { return this.GetString(39, 30); }

            set { this.SetString(value, 39, 30); }
        }  
        #endregion

    }

  
    public partial class DiverseDistrictType: Wrapper
    {
        #region Common
        public override int Length
        {
            get { return 68; }
        }
        #endregion
        
        #region Properties
    
        ///  <summary>
        /// Danish: KOMKOD
        /// The municipality code
        ///  </summary>
        public decimal MunicipalityCode
        {
            get { return this.GetDecimal(4, 4); }

            set { this.SetDecimal(value, 4, 4); }
        }  
        ///  <summary>
        /// Danish: VEJKOD
        /// The street code
        ///  </summary>
        public decimal StreetCode
        {
            get { return this.GetDecimal(8, 4); }

            set { this.SetDecimal(value, 8, 4); }
        }  
        ///  <summary>
        /// Danish: HUSNRFRA
        /// House number from
        ///  </summary>
        public decimal HouseNumberFrom
        {
            get { return this.GetDecimal(12, 4); }

            set { this.SetDecimal(value, 12, 4); }
        }  
        ///  <summary>
        /// Danish: HUSNRTIL
        /// House number to
        ///  </summary>
        public decimal HouseNumberTo
        {
            get { return this.GetDecimal(16, 4); }

            set { this.SetDecimal(value, 16, 4); }
        }  
        ///  <summary>
        /// Danish: LIGEULIGE
        /// Equal or unequal house number
        ///  </summary>
        public char EqualOrUnequal
        {
            get { return this.GetChar(20); }

            set { this.SetChar(value, 20); }
        }  
        ///  <summary>
        /// Danish: TIMESTAMP
        /// Date of report
        ///  </summary>
        public DateTime? Timestamp
        {
            get { return this.GetDateTime(21, 12, "yyyyMMddHHmm"); }

            set { this.SetDateTime(value, 21, 12, "yyyyMMddHHmm"); }
        }  
        ///  <summary>
        /// Danish: DISTTYP
        /// District type
        ///  </summary>
        public decimal DistrictType
        {
            get { return this.GetDecimal(33, 2); }

            set { this.SetDecimal(value, 33, 2); }
        }  
        ///  <summary>
        /// Danish: DIVDISTKOD
        /// Diverse district code
        ///  </summary>
        public string DivDistrictCode
        {
            get { return this.GetString(35, 4); }

            set { this.SetString(value, 35, 4); }
        }  
        ///  <summary>
        /// Danish: DISTTXT
        /// District text
        ///  </summary>
        public string DistrictText
        {
            get { return this.GetString(39, 30); }

            set { this.SetString(value, 39, 30); }
        }  
        #endregion

    }

  
    public partial class EvacuationDistrictType: Wrapper
    {
        #region Common
        public override int Length
        {
            get { return 63; }
        }
        #endregion
        
        #region Properties
    
        ///  <summary>
        /// Danish: KOMKOD
        /// The municipality code
        ///  </summary>
        public decimal MunicipalityCode
        {
            get { return this.GetDecimal(4, 4); }

            set { this.SetDecimal(value, 4, 4); }
        }  
        ///  <summary>
        /// Danish: VEJKOD
        /// The street code
        ///  </summary>
        public decimal StreetCode
        {
            get { return this.GetDecimal(8, 4); }

            set { this.SetDecimal(value, 8, 4); }
        }  
        ///  <summary>
        /// Danish: HUSNRFRA
        /// House number from
        ///  </summary>
        public decimal HouseNumberFrom
        {
            get { return this.GetDecimal(12, 4); }

            set { this.SetDecimal(value, 12, 4); }
        }  
        ///  <summary>
        /// Danish: HUSNRTIL
        /// House number to
        ///  </summary>
        public decimal HouseNumberTo
        {
            get { return this.GetDecimal(16, 4); }

            set { this.SetDecimal(value, 16, 4); }
        }  
        ///  <summary>
        /// Danish: LIGEULIGE
        /// Equal or unequal house number
        ///  </summary>
        public char EqualOrUnequal
        {
            get { return this.GetChar(20); }

            set { this.SetChar(value, 20); }
        }  
        ///  <summary>
        /// Danish: TIMESTAMP
        /// Date of report
        ///  </summary>
        public DateTime? Timestamp
        {
            get { return this.GetDateTime(21, 12, "yyyyMMddHHmm"); }

            set { this.SetDateTime(value, 21, 12, "yyyyMMddHHmm"); }
        }  
        ///  <summary>
        /// Danish: EVAKUERKOD
        /// Evacuation code
        ///  </summary>
        public decimal EvacuationCode
        {
            get { return this.GetDecimal(33, 1); }

            set { this.SetDecimal(value, 33, 1); }
        }  
        ///  <summary>
        /// Danish: DISTTXT
        /// District text
        ///  </summary>
        public string DistrictText
        {
            get { return this.GetString(34, 30); }

            set { this.SetString(value, 34, 30); }
        }  
        #endregion

    }

  
    public partial class ChurchDistrictType: Wrapper
    {
        #region Common
        public override int Length
        {
            get { return 64; }
        }
        #endregion
        
        #region Properties
    
        ///  <summary>
        /// Danish: KOMKOD
        /// The municipality code
        ///  </summary>
        public decimal MunicipalityCode
        {
            get { return this.GetDecimal(4, 4); }

            set { this.SetDecimal(value, 4, 4); }
        }  
        ///  <summary>
        /// Danish: VEJKOD
        /// The street code
        ///  </summary>
        public decimal StreetCode
        {
            get { return this.GetDecimal(8, 4); }

            set { this.SetDecimal(value, 8, 4); }
        }  
        ///  <summary>
        /// Danish: HUSNRFRA
        /// House number from
        ///  </summary>
        public decimal HouseNumberFrom
        {
            get { return this.GetDecimal(12, 4); }

            set { this.SetDecimal(value, 12, 4); }
        }  
        ///  <summary>
        /// Danish: HUSNRTIL
        /// House number to
        ///  </summary>
        public decimal HouseNumberTo
        {
            get { return this.GetDecimal(16, 4); }

            set { this.SetDecimal(value, 16, 4); }
        }  
        ///  <summary>
        /// Danish: LIGEULIGE
        /// Equal or unequal house number
        ///  </summary>
        public char EqualOrUnequal
        {
            get { return this.GetChar(20); }

            set { this.SetChar(value, 20); }
        }  
        ///  <summary>
        /// Danish: TIMESTAMP
        /// Date of report
        ///  </summary>
        public DateTime? Timestamp
        {
            get { return this.GetDateTime(21, 12, "yyyyMMddHHmm"); }

            set { this.SetDateTime(value, 21, 12, "yyyyMMddHHmm"); }
        }  
        ///  <summary>
        /// Danish: KIRKEKOD
        /// Church district code
        ///  </summary>
        public decimal ChurchDistrictCode
        {
            get { return this.GetDecimal(33, 2); }

            set { this.SetDecimal(value, 33, 2); }
        }  
        ///  <summary>
        /// Danish: DISTTXT
        /// District text
        ///  </summary>
        public string DistrictText
        {
            get { return this.GetString(35, 30); }

            set { this.SetString(value, 35, 30); }
        }  
        #endregion

    }

  
    public partial class SchoolDistrictType: Wrapper
    {
        #region Common
        public override int Length
        {
            get { return 64; }
        }
        #endregion
        
        #region Properties
    
        ///  <summary>
        /// Danish: KOMKOD
        /// The municipality code
        ///  </summary>
        public decimal MunicipalityCode
        {
            get { return this.GetDecimal(4, 4); }

            set { this.SetDecimal(value, 4, 4); }
        }  
        ///  <summary>
        /// Danish: VEJKOD
        /// The street code
        ///  </summary>
        public decimal StreetCode
        {
            get { return this.GetDecimal(8, 4); }

            set { this.SetDecimal(value, 8, 4); }
        }  
        ///  <summary>
        /// Danish: HUSNRFRA
        /// House number from
        ///  </summary>
        public decimal HouseNumberFrom
        {
            get { return this.GetDecimal(12, 4); }

            set { this.SetDecimal(value, 12, 4); }
        }  
        ///  <summary>
        /// Danish: HUSNRTIL
        /// House number to
        ///  </summary>
        public decimal HouseNumberTo
        {
            get { return this.GetDecimal(16, 4); }

            set { this.SetDecimal(value, 16, 4); }
        }  
        ///  <summary>
        /// Danish: LIGEULIGE
        /// Equal or unequal house number
        ///  </summary>
        public char EqualOrUnequal
        {
            get { return this.GetChar(20); }

            set { this.SetChar(value, 20); }
        }  
        ///  <summary>
        /// Danish: TIMESTAMP
        /// Date of report
        ///  </summary>
        public DateTime? Timestamp
        {
            get { return this.GetDateTime(21, 12, "yyyyMMddHHmm"); }

            set { this.SetDateTime(value, 21, 12, "yyyyMMddHHmm"); }
        }  
        ///  <summary>
        /// Danish: SKOLEKOD
        /// School code
        ///  </summary>
        public decimal SchoolCode
        {
            get { return this.GetDecimal(33, 2); }

            set { this.SetDecimal(value, 33, 2); }
        }  
        ///  <summary>
        /// Danish: DISTTXT
        /// District text
        ///  </summary>
        public string DistrictText
        {
            get { return this.GetString(35, 30); }

            set { this.SetString(value, 35, 30); }
        }  
        #endregion

    }

  
    public partial class PopulationDistrictType: Wrapper
    {
        #region Common
        public override int Length
        {
            get { return 66; }
        }
        #endregion
        
        #region Properties
    
        ///  <summary>
        /// Danish: KOMKOD
        /// The municipality code
        ///  </summary>
        public decimal MunicipalityCode
        {
            get { return this.GetDecimal(4, 4); }

            set { this.SetDecimal(value, 4, 4); }
        }  
        ///  <summary>
        /// Danish: VEJKOD
        /// The street code
        ///  </summary>
        public decimal StreetCode
        {
            get { return this.GetDecimal(8, 4); }

            set { this.SetDecimal(value, 8, 4); }
        }  
        ///  <summary>
        /// Danish: HUSNRFRA
        /// House number from
        ///  </summary>
        public decimal HouseNumberFrom
        {
            get { return this.GetDecimal(12, 4); }

            set { this.SetDecimal(value, 12, 4); }
        }  
        ///  <summary>
        /// Danish: HUSNRTIL
        /// House number to
        ///  </summary>
        public decimal HouseNumberTo
        {
            get { return this.GetDecimal(16, 4); }

            set { this.SetDecimal(value, 16, 4); }
        }  
        ///  <summary>
        /// Danish: LIGEULIGE
        /// Equal or unequal house number
        ///  </summary>
        public char EqualOrUnequal
        {
            get { return this.GetChar(20); }

            set { this.SetChar(value, 20); }
        }  
        ///  <summary>
        /// Danish: TIMESTAMP
        /// Date of report
        ///  </summary>
        public DateTime? Timestamp
        {
            get { return this.GetDateTime(21, 12, "yyyyMMddHHmm"); }

            set { this.SetDateTime(value, 21, 12, "yyyyMMddHHmm"); }
        }  
        ///  <summary>
        /// Danish: BEFOLKKOD
        /// Heating district code
        ///  </summary>
        public decimal PopulationDistrictCode
        {
            get { return this.GetDecimal(33, 4); }

            set { this.SetDecimal(value, 33, 4); }
        }  
        ///  <summary>
        /// Danish: DISTTXT
        /// District text
        ///  </summary>
        public string DistrictText
        {
            get { return this.GetString(37, 30); }

            set { this.SetString(value, 37, 30); }
        }  
        #endregion

    }

  
    public partial class SocialDistrictType: Wrapper
    {
        #region Common
        public override int Length
        {
            get { return 64; }
        }
        #endregion
        
        #region Properties
    
        ///  <summary>
        /// Danish: KOMKOD
        /// The municipality code
        ///  </summary>
        public decimal MunicipalityCode
        {
            get { return this.GetDecimal(4, 4); }

            set { this.SetDecimal(value, 4, 4); }
        }  
        ///  <summary>
        /// Danish: VEJKOD
        /// The street code
        ///  </summary>
        public decimal StreetCode
        {
            get { return this.GetDecimal(8, 4); }

            set { this.SetDecimal(value, 8, 4); }
        }  
        ///  <summary>
        /// Danish: HUSNRFRA
        /// House number from
        ///  </summary>
        public decimal HouseNumberFrom
        {
            get { return this.GetDecimal(12, 4); }

            set { this.SetDecimal(value, 12, 4); }
        }  
        ///  <summary>
        /// Danish: HUSNRTIL
        /// House number to
        ///  </summary>
        public decimal HouseNumberTo
        {
            get { return this.GetDecimal(16, 4); }

            set { this.SetDecimal(value, 16, 4); }
        }  
        ///  <summary>
        /// Danish: LIGEULIGE
        /// Equal or unequal house number
        ///  </summary>
        public char EqualOrUnequal
        {
            get { return this.GetChar(20); }

            set { this.SetChar(value, 20); }
        }  
        ///  <summary>
        /// Danish: TIMESTAMP
        /// Date of report
        ///  </summary>
        public DateTime? Timestamp
        {
            get { return this.GetDateTime(21, 12, "yyyyMMddHHmm"); }

            set { this.SetDateTime(value, 21, 12, "yyyyMMddHHmm"); }
        }  
        ///  <summary>
        /// Danish: SOCIALKOD
        /// Social code
        ///  </summary>
        public decimal SocialCode
        {
            get { return this.GetDecimal(33, 2); }

            set { this.SetDecimal(value, 33, 2); }
        }  
        ///  <summary>
        /// Danish: DISTTXT
        /// District text
        ///  </summary>
        public string DistrictText
        {
            get { return this.GetString(35, 30); }

            set { this.SetString(value, 35, 30); }
        }  
        #endregion

    }

  
    public partial class ChurchAdministrationDistrictType: Wrapper
    {
        #region Common
        public override int Length
        {
            get { return 56; }
        }
        #endregion
        
        #region Properties
    
        ///  <summary>
        /// Danish: KOMKOD
        /// The municipality code
        ///  </summary>
        public decimal MunicipalityCode
        {
            get { return this.GetDecimal(4, 4); }

            set { this.SetDecimal(value, 4, 4); }
        }  
        ///  <summary>
        /// Danish: VEJKOD
        /// The street code
        ///  </summary>
        public decimal StreetCode
        {
            get { return this.GetDecimal(8, 4); }

            set { this.SetDecimal(value, 8, 4); }
        }  
        ///  <summary>
        /// Danish: HUSNRFRA
        /// House number from
        ///  </summary>
        public decimal HouseNumberFrom
        {
            get { return this.GetDecimal(12, 4); }

            set { this.SetDecimal(value, 12, 4); }
        }  
        ///  <summary>
        /// Danish: HUSNRTIL
        /// House number to
        ///  </summary>
        public decimal HouseNumberTo
        {
            get { return this.GetDecimal(16, 4); }

            set { this.SetDecimal(value, 16, 4); }
        }  
        ///  <summary>
        /// Danish: LIGEULIGE
        /// Equal or unequal house number
        ///  </summary>
        public char EqualOrUnequal
        {
            get { return this.GetChar(20); }

            set { this.SetChar(value, 20); }
        }  
        ///  <summary>
        /// Danish: TIMESTAMP
        /// Date of report
        ///  </summary>
        public DateTime? Timestamp
        {
            get { return this.GetDateTime(21, 12, "yyyyMMddHHmm"); }

            set { this.SetDateTime(value, 21, 12, "yyyyMMddHHmm"); }
        }  
        ///  <summary>
        /// Danish: MYNKOD-CTSOGNEDIST
        /// Authority and church code
        ///  </summary>
        public decimal AuthorityAndChurchCode
        {
            get { return this.GetDecimal(33, 4); }

            set { this.SetDecimal(value, 33, 4); }
        }  
        ///  <summary>
        /// Danish: MYNNVN
        /// Authority name
        ///  </summary>
        public string AuthorityName
        {
            get { return this.GetString(37, 20); }

            set { this.SetString(value, 37, 20); }
        }  
        #endregion

    }

  
    public partial class ElectionDistrictType: Wrapper
    {
        #region Common
        public override int Length
        {
            get { return 64; }
        }
        #endregion
        
        #region Properties
    
        ///  <summary>
        /// Danish: KOMKOD
        /// The municipality code
        ///  </summary>
        public decimal MunicipalityCode
        {
            get { return this.GetDecimal(4, 4); }

            set { this.SetDecimal(value, 4, 4); }
        }  
        ///  <summary>
        /// Danish: VEJKOD
        /// The street code
        ///  </summary>
        public decimal StreetCode
        {
            get { return this.GetDecimal(8, 4); }

            set { this.SetDecimal(value, 8, 4); }
        }  
        ///  <summary>
        /// Danish: HUSNRFRA
        /// House number from
        ///  </summary>
        public decimal HouseNumberFrom
        {
            get { return this.GetDecimal(12, 4); }

            set { this.SetDecimal(value, 12, 4); }
        }  
        ///  <summary>
        /// Danish: HUSNRTIL
        /// House number to
        ///  </summary>
        public decimal HouseNumberTo
        {
            get { return this.GetDecimal(16, 4); }

            set { this.SetDecimal(value, 16, 4); }
        }  
        ///  <summary>
        /// Danish: LIGEULIGE
        /// Equal or unequal house number
        ///  </summary>
        public char EqualOrUnequal
        {
            get { return this.GetChar(20); }

            set { this.SetChar(value, 20); }
        }  
        ///  <summary>
        /// Danish: TIMESTAMP
        /// Date of report
        ///  </summary>
        public DateTime? Timestamp
        {
            get { return this.GetDateTime(21, 12, "yyyyMMddHHmm"); }

            set { this.SetDateTime(value, 21, 12, "yyyyMMddHHmm"); }
        }  
        ///  <summary>
        /// Danish: VALGKOD
        /// Election code
        ///  </summary>
        public decimal ElectionCode
        {
            get { return this.GetDecimal(33, 2); }

            set { this.SetDecimal(value, 33, 2); }
        }  
        ///  <summary>
        /// Danish: DISTTXT
        /// District text
        ///  </summary>
        public string DistrictText
        {
            get { return this.GetString(35, 30); }

            set { this.SetString(value, 35, 30); }
        }  
        #endregion

    }

  
    public partial class HeatingDistrictType: Wrapper
    {
        #region Common
        public override int Length
        {
            get { return 66; }
        }
        #endregion
        
        #region Properties
    
        ///  <summary>
        /// Danish: KOMKOD
        /// The municipality code
        ///  </summary>
        public decimal MunicipalityCode
        {
            get { return this.GetDecimal(4, 4); }

            set { this.SetDecimal(value, 4, 4); }
        }  
        ///  <summary>
        /// Danish: VEJKOD
        /// The street code
        ///  </summary>
        public decimal StreetCode
        {
            get { return this.GetDecimal(8, 4); }

            set { this.SetDecimal(value, 8, 4); }
        }  
        ///  <summary>
        /// Danish: HUSNRFRA
        /// House number from
        ///  </summary>
        public decimal HouseNumberFrom
        {
            get { return this.GetDecimal(12, 4); }

            set { this.SetDecimal(value, 12, 4); }
        }  
        ///  <summary>
        /// Danish: HUSNRTIL
        /// House number to
        ///  </summary>
        public decimal HouseNumberTo
        {
            get { return this.GetDecimal(16, 4); }

            set { this.SetDecimal(value, 16, 4); }
        }  
        ///  <summary>
        /// Danish: LIGEULIGE
        /// Equal or unequal house number
        ///  </summary>
        public char EqualOrUnequal
        {
            get { return this.GetChar(20); }

            set { this.SetChar(value, 20); }
        }  
        ///  <summary>
        /// Danish: TIMESTAMP
        /// Date of report
        ///  </summary>
        public DateTime? Timestamp
        {
            get { return this.GetDateTime(21, 12, "yyyyMMddHHmm"); }

            set { this.SetDateTime(value, 21, 12, "yyyyMMddHHmm"); }
        }  
        ///  <summary>
        /// Danish: VARMEKOD
        /// Heating district code
        ///  </summary>
        public decimal HeatingDistrictCode
        {
            get { return this.GetDecimal(33, 2); }

            set { this.SetDecimal(value, 33, 2); }
        }  
        ///  <summary>
        /// Danish: DISTTXT
        /// District text
        ///  </summary>
        public string DistrictText
        {
            get { return this.GetString(35, 30); }

            set { this.SetString(value, 35, 30); }
        }  
        #endregion

    }

  
    public partial class CouncilType: Wrapper
    {
        #region Common
        public override int Length
        {
            get { return 66; }
        }
        #endregion
        
        #region Properties
    
        ///  <summary>
        /// Danish: KOMKOD
        /// The municipality code
        ///  </summary>
        public decimal MunicipalityCode
        {
            get { return this.GetDecimal(4, 4); }

            set { this.SetDecimal(value, 4, 4); }
        }  
        ///  <summary>
        /// Danish: MYNTYP
        /// The street code
        ///  </summary>
        public decimal AuthorityCode
        {
            get { return this.GetDecimal(8, 2); }

            set { this.SetDecimal(value, 8, 2); }
        }  
        ///  <summary>
        /// Danish: MYNGRP
        /// House number from
        ///  </summary>
        public decimal AuthorityGroup
        {
            get { return this.GetDecimal(10, 1); }

            set { this.SetDecimal(value, 10, 1); }
        }  
        ///  <summary>
        /// Danish: MYNNVN
        /// House number to
        ///  </summary>
        public string HouseNumberTo
        {
            get { return this.GetString(55, 20); }

            set { this.SetString(value, 55, 20); }
        }  
        #endregion

    }

  
    public partial class PostNumberType: Wrapper
    {
        #region Common
        public override int Length
        {
            get { return 66; }
        }
        #endregion
        
        #region Properties
    
        ///  <summary>
        /// Danish: POSTNR
        /// The post code
        ///  </summary>
        public decimal PostCode
        {
            get { return this.GetDecimal(61, 4); }

            set { this.SetDecimal(value, 61, 4); }
        }  
        ///  <summary>
        /// Danish: POSTDISTTXT
        /// The post text
        ///  </summary>
        public string PostText
        {
            get { return this.GetString(65, 20); }

            set { this.SetString(value, 65, 20); }
        }  
        #endregion

    }

  
    }
  