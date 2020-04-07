using System;
namespace CovidNET_lib
{
    internal class CovidDataManager
    {
        private static CovidDataManager _instance;
        private static object _lockRoot = new object();
        private CovidDataManager()
        {
        }

        internal string CovidJsonSource { get; set; }

        public static CovidDataManager Instance
        {
			get
            {
				if(_instance == null)
                {
					lock(_instance)
                    {
						if(_instance == null) 
						{
                            _instance = new CovidDataManager();
						} 
					} 
				}
                return _instance;
            }
		}


    }
}
