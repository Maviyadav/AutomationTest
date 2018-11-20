using System;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace AutomationTest.Fragments
{
 public class MainMenuFragment : Android.Support.V4.App.Fragment  {
        Button btnEnterPackage;
        Button btnShowPackage;
        public MainMenuFragment()         {          }       public static Android.Support.V4.App.Fragment newInstance(Context context)      {             MainMenuFragment busrouteFragment = new MainMenuFragment();           return busrouteFragment;        }       public override void OnCreate(Bundle savedInstanceState)        {           base.OnCreate(savedInstanceState);          }       public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)      {             ViewGroup view = (ViewGroup)inflater.Inflate(Resource.Layout.mainmenufragment, null);
            btnEnterPackage = view.FindViewById<Button>(Resource.Id.btnEnter);
            btnShowPackage = view.FindViewById<Button>(Resource.Id.btnShow);
            btnEnterPackage.Click += BtnEnterPackage_Click;
            btnShowPackage.Click += BtnShowPackage_Click;             return view;        }

        private void BtnEnterPackage_Click(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
               
            }
        }

        private void BtnShowPackage_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }
    }  } 