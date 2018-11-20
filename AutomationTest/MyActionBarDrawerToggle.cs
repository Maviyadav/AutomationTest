using System;
using SupportActionBarDrawerToggle = Android.Support.V7.App.ActionBarDrawerToggle;
using Android.Support.V7.App;
using Android.Support.V4.Widget;

namespace AutomationTest
{
	public class MyActionBarDrawerToggle : SupportActionBarDrawerToggle
	{
		private ActionBarActivity mHostActivity;
		private int mOpenedResource;
		private int mClosedResource;
        private int mShowResource;

        public MyActionBarDrawerToggle (ActionBarActivity host, DrawerLayout drawerLayout, int mainmenu, int enterpackage) 
            : base(host, drawerLayout, mainmenu, enterpackage)
        {
			mHostActivity = host;
			mOpenedResource = mainmenu;
			mClosedResource = enterpackage;
        }

		public override void OnDrawerOpened (Android.Views.View drawerView)
		{	
			int drawerType = (int)drawerView.Tag;

			if (drawerType == 0)
			{
				base.OnDrawerOpened (drawerView);
				//mHostActivity.SupportActionBar.SetTitle(mOpenedResource);
			}
		}

		public override void OnDrawerClosed (Android.Views.View drawerView)
		{
			int drawerType = (int)drawerView.Tag;

			if (drawerType == 0)
			{
				base.OnDrawerClosed (drawerView);
				//mHostActivity.SupportActionBar.SetTitle(mClosedResource);
			}				
		}

		public override void OnDrawerSlide (Android.Views.View drawerView, float slideOffset)
		{
			int drawerType = (int)drawerView.Tag;

			if (drawerType == 0)
			{
				base.OnDrawerSlide (drawerView, slideOffset);
			}
		}
	}
}

