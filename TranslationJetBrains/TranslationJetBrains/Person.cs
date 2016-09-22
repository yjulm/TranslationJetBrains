using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TranslationJetBrains
{
    #region 新的API商店翻译服务
    //{
    //    "from":"en",
    //    "to":"zh",
    //    "trans_result":[
    //        {
    //            "src":"Capture memory allocations data",
    //            "dst":"捕获内存分配数据"
    //        }
    //    ]
    //}

    [DataContract]
    public class ApiStoreRetData : Serializer.Person
    {
        [DataMember(Order = 1)]
        public string from { get; set; }

        [DataMember(Order = 2)]
        public string to { get; set; }

        [DataMember(Order = 3)]
        public List<ApiStoreResult> trans_result { get; set; }
    }

    [DataContract]
    public class ApiStoreResult
    {
        [DataMember(Order = 1)]
        public string src { get; set; }

        [DataMember(Order = 2)]
        public string dst { get; set; }
    }

    #endregion 新的API商店翻译服务
}