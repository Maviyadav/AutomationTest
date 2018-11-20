using System;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using AutomationTest.Database;

namespace AutomationTest.Fragments
{
    public class EnterPackageDimmsFragment : Android.Support.V4.App.Fragment     {         Context context;         Button btnSave;         Button btnReset;         EditText txtBarcode;         EditText txtHeight;         EditText txtWidth;         EditText txtDepth;         string barcode, height, width, depth;
        DateTime dateTime;         public EnterPackageDimmsFragment(Context _context)         {             context = _context;         }
       
        public override void OnCreate(Bundle savedInstanceState)         {             base.OnCreate(savedInstanceState);          }         public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)         {             ViewGroup view = (ViewGroup)inflater.Inflate(Resource.Layout.enterpackagedimmsfragment, null);              txtBarcode = view.FindViewById<EditText>(Resource.Id.txtBarcode);             txtHeight = view.FindViewById<EditText>(Resource.Id.txtHeight);             txtWidth = view.FindViewById<EditText>(Resource.Id.txtWidth);             txtDepth = view.FindViewById<EditText>(Resource.Id.txtDepth);             btnSave = view.FindViewById<Button>(Resource.Id.btnSave);             btnReset = view.FindViewById<Button>(Resource.Id.btnReset);             btnSave.Click += BtnSave_Click;             btnReset.Click += BtnReset_Click;              return view;         }           private void BtnSave_Click(object sender, EventArgs e)         {             try             {
                bool isValidate = ValidateInput();

                if(isValidate)
                {
                    BarcodeTable tblBarcode = new BarcodeTable();
                    tblBarcode.Barcode = txtBarcode.Text;
                    tblBarcode.Height = txtHeight.Text;
                    tblBarcode.Width = txtWidth.Text;
                    tblBarcode.Depth = txtDepth.Text;
                    tblBarcode.InsertedDate = DateTime.Now;
                    DatabaseBuilder.SaveBarcodeInfo(tblBarcode);
                    clear();
                    Toast.MakeText(context, "Barcode Store Successfully...!", ToastLength.Short).Show();
                }                             }             catch (Exception ex)             {                 Toast.MakeText(context, ex.ToString(), ToastLength.Short).Show();             }         }           private void BtnReset_Click(object sender, EventArgs e)         {             try             {                 clear();             }             catch (Exception ex)             {                 Toast.MakeText(context, ex.ToString(), ToastLength.Short).Show();             }         }           void clear()         {             txtBarcode.Text = "";             txtHeight.Text = "";             txtWidth.Text = "";             txtDepth.Text = "";         }

        bool ValidateInput()
        {
            if (txtBarcode.Text.Equals(""))
            {
                txtBarcode.RequestFocus();
                txtBarcode.SetError("Barcode can not be left blank!", null);
                return false;
            }
            else if (txtHeight.Text.Equals(""))
            {
                txtHeight.RequestFocus();
                txtHeight.SetError("Height can not be left blank!", null);
                return false;
            }
            else if (txtWidth.Text.Equals(""))
            {
                txtWidth.RequestFocus();
                txtWidth.SetError("Width can not be left blank!", null);
                return false;
            }
            else if (txtDepth.Text.Equals(""))
            {
                txtDepth.RequestFocus();
                txtDepth.SetError("Depth can not be left blank!", null);
                return false;
            }
            return true;
        }     }  }    