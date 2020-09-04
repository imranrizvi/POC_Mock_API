using System;

namespace Model
{
    [Serializable]
    public class EsdResponseWithMock:EsdResponse
    {
        public bool Result { get; set; }
    }
}
