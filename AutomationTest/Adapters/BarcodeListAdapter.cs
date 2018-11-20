using System;
using System.Collections.Generic;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using AutomationTest.Database;
namespace AutomationTest.Adapters
{
    public class BarcodeListAdapter : BaseAdapter<BarcodeTable>
    {
        Context context;
        LayoutInflater inflater;
        List<BarcodeTable> list;

        public BarcodeListAdapter(Context _context, List<BarcodeTable> _list)
            : base() 
        {
            this.context = _context;
            inflater = LayoutInflater.FromContext(context);
            this.list = _list;
        }

        public override int Count
        {
            get { return list.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override BarcodeTable this[int index]
        {
            get { return list[index]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;

            if (view == null)

             view = inflater.Inflate(Resource.Layout.BarcodeListLayout, parent, false);

                BarcodeTable item = this[position];
            view.FindViewById<TextView> (Resource.Id.lblBarcode).Text = item.Barcode;
            view.FindViewById<TextView>(Resource.Id.lblHeight).Text = "Height, Width, Depth  =" +  item.Height +", "+ item.Width + ", " + item.Height;

            return view;
        }
    }
}