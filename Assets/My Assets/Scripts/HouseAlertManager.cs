using UnityEngine;


    public class HouseAlertManager : Singleton<HouseAlertManager>
    {
        protected HouseAlertManager() { }

        public bool grateMsg1 = false;
        public bool grateMsg2 = false;
        public bool doorMsg = false;
        public bool strafeMsg = false;
        public bool lightMsg = false;
        public bool escapeMsg = false;
	public bool ghoulMessage = false;
	public bool leverlMessage = false;

    }
