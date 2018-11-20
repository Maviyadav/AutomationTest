using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using AutomationTest.Adapters;
using AutomationTest.Database;

namespace AutomationTest.Fragments
{
    public class ShowPackagesFragment :  Android.Support.V4.App.Fragment     {
        ListView listView;
        Context context;         public  ShowPackagesFragment(Context _context)         {
            context = _context;
              
        }


        public override void OnCreate(Bundle savedInstanceState)         {             base.OnCreate(savedInstanceState);          }         public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)         {             ViewGroup view = (ViewGroup)inflater.Inflate(Resource.Layout.showpackagesfragment, null);
            listView = view.FindViewById<ListView>(Resource.Id.listView);
            var lstBarcode = DatabaseBuilder.GetBarcodeInfo();
            listView.Adapter = new BarcodeListAdapter(context as Activity, lstBarcode);             return view;         }     }
}
