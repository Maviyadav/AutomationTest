using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using SupportFragment = Android.Support.V4.App.Fragment;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using System.Collections.Generic;
using AutomationTest.Database;
using AutomationTest.Fragments;

namespace AutomationTest
{
    [Activity(Label = "Automation", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/MyTheme")]
    public class MainActivity : ActionBarActivity
    {
        private SupportToolbar mToolbar;
        private MyActionBarDrawerToggle mDrawerToggle;
        private DrawerLayout mDrawerLayout;
        private ListView mLeftDrawer;
        private MainMenuFragment mainMenuFragment;
        private EnterPackageDimmsFragment enterPackageDimmsFragment;
        private ShowPackagesFragment showPackagesFragment;
        private SupportFragment mCurrentFragment = new SupportFragment();
        private Stack<SupportFragment> mStackFragments;
      
        private ArrayAdapter mLeftAdapter;

        private List<string> mLeftDataSet;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            try
            {
                // Set our view from the "main" layout resource
                SetContentView(Resource.Layout.Main);

                DatabaseBuilder.CreateDatabase();
                DatabaseBuilder.CreateTables();

                mToolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
                mToolbar.Menu.SetGroupVisible(2, true);
                mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
                mLeftDrawer = FindViewById<ListView>(Resource.Id.left_drawer);

                mainMenuFragment = new MainMenuFragment();
                enterPackageDimmsFragment = new EnterPackageDimmsFragment(this);
                showPackagesFragment = new ShowPackagesFragment(this);
                mStackFragments = new Stack<SupportFragment>();


                mLeftDrawer.Tag = 0;


                SetSupportActionBar(mToolbar);

                mLeftDataSet = new List<string>();
                mLeftDataSet.Add("Main Menu Screen");
                mLeftDataSet.Add("Enter Package Screen");
                mLeftDataSet.Add("Show Package Screen");
                mLeftAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, mLeftDataSet);
                mLeftDrawer.Adapter = mLeftAdapter;
                mLeftDrawer.ItemClick += MenuListView_ItemClick;


                mDrawerToggle = new MyActionBarDrawerToggle(this, mDrawerLayout, Resource.String.mainmenu, Resource.String.enterpackage
                );

                mDrawerLayout.SetDrawerListener(mDrawerToggle);
                SupportActionBar.SetHomeButtonEnabled(true);
                SupportActionBar.SetDisplayShowTitleEnabled(true);
                mDrawerToggle.SyncState();

                Android.Support.V4.App.FragmentTransaction tx = SupportFragmentManager.BeginTransaction();

                tx.Add(Resource.Id.main, mainMenuFragment);
                tx.Add(Resource.Id.main, enterPackageDimmsFragment);
                tx.Add(Resource.Id.main, showPackagesFragment);
                tx.Hide(enterPackageDimmsFragment);
                tx.Hide(showPackagesFragment);

                mCurrentFragment = mainMenuFragment;
                tx.Commit();

            }
            catch (Exception ex)
            {
                //  ex.Message;
            }
        }
        void MenuListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Android.Support.V4.App.Fragment fragment = null;

            switch (e.Id)
            {
                case 0:
                    ShowFragment(mainMenuFragment);
                    setToolbarBottomTitle(Resource.String.mainmenu);
                    break;
                case 1:
                    ShowFragment(enterPackageDimmsFragment);
                    setToolbarBottomTitle(Resource.String.enterpackage);
                    break;
                case 2:
                    ShowFragment(showPackagesFragment);
                    setToolbarBottomTitle(Resource.String.showpackage);
                    break;
            }

            //SupportFragmentManager.BeginTransaction().Replace(Resource.Id.main, fragment).Commit();


            mDrawerLayout.CloseDrawers();
            mDrawerToggle.SyncState();

        }

        private void setToolbarBottomTitle(int title)
        {

            SupportActionBar.SetTitle(title);
        }

        private void ShowFragment(SupportFragment fragment)
        {

            if (fragment.IsVisible)
            {
                return;
            }

            var trans = SupportFragmentManager.BeginTransaction();


            fragment.View.BringToFront();
            mCurrentFragment.View.BringToFront();

            trans.Hide(mCurrentFragment);
            trans.Show(fragment);

            trans.AddToBackStack(null);
            mStackFragments.Push(mCurrentFragment);
            trans.Commit();

            mCurrentFragment = fragment;

        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {


                case Android.Resource.Id.Home:
                    //The hamburger icon was clicked which means the drawer toggle will handle the event

                    mDrawerToggle.OnOptionsItemSelected(item);
                    return true;

                case Resource.Id.action_mainmenu:
                    ShowFragment(mainMenuFragment);
                    setToolbarBottomTitle(Resource.String.mainmenu);
                    
            return true;

                case Resource.Id.action_enterpackage:
                    ShowFragment(enterPackageDimmsFragment);
                    setToolbarBottomTitle(Resource.String.enterpackage);
                    return true;
                case Resource.Id.action_showpackage:
                    ShowFragment(showPackagesFragment);
                    setToolbarBottomTitle(Resource.String.showpackage);
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.action_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            if (mDrawerLayout.IsDrawerOpen((int)GravityFlags.Left))
            {
                outState.PutString("DrawerState", "Opened");
            }

            else
            {
                outState.PutString("DrawerState", "Closed");
            }

            base.OnSaveInstanceState(outState);
        }

        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);
            mDrawerToggle.SyncState();
        }

        public override void OnConfigurationChanged(Android.Content.Res.Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            mDrawerToggle.OnConfigurationChanged(newConfig);
        }
    }
}


