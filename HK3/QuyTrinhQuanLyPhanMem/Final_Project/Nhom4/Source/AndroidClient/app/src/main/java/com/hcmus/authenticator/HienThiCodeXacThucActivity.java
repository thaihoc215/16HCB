package com.hcmus.authenticator;

import android.app.Application;
import android.app.Dialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.graphics.drawable.Drawable;
import android.net.ConnectivityManager;
import android.os.Bundle;
import android.os.CountDownTimer;
import android.support.design.widget.FloatingActionButton;
import android.support.v4.content.ContextCompat;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.text.Spannable;
import android.text.SpannableString;
import android.text.style.ForegroundColorSpan;
import android.util.Log;
import android.view.ContextMenu;
import android.view.Gravity;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;

import android.view.Window;
import android.view.WindowManager;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.ImageButton;
import android.widget.ListView;
import android.widget.Toast;

import com.mikhaellopez.circularprogressbar.CircularProgressBar;

import java.security.InvalidKeyException;
import java.security.NoSuchAlgorithmException;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.Map;

import retrofit.Call;
import retrofit.Callback;
import retrofit.GsonConverterFactory;
import retrofit.Response;
import retrofit.Retrofit;
import retrofit.http.GET;
import retrofit.http.Query;

public class HienThiCodeXacThucActivity extends AppCompatActivity implements Callback<HienThiCodeXacThucActivity.TaiKhoanDangNhap> {


    ListView lstDanhSachTaiKhoan;
    ArrayList<TaiKhoan> dsTaiKhoan=new ArrayList<TaiKhoan>();
    HienThiMaXacThucAdapter adapter;
    final Context context=this;
    public CircularProgressBar progressBar;
    String secretKey;
    float progress;
    int giay;
    int k=0;
    CountDownTimer timer1, timer2;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_hien_thi_code_xac_thuc);
        progressBar=(CircularProgressBar)findViewById(R.id.progressThoiGian);
        lstDanhSachTaiKhoan=(ListView)findViewById(R.id.lstDanhSachTaiKhoan);
        registerForContextMenu(lstDanhSachTaiKhoan);


        Toolbar myToolbar=(Toolbar)findViewById(R.id.my_toolbar);
        Drawable drawable = ContextCompat.getDrawable(getApplicationContext(),R.mipmap.icon_option_menu);
        myToolbar.setOverflowIcon(drawable);
        setSupportActionBar(myToolbar);

        // Get a support ActionBar corresponding to this toolbar
        /*ActionBar ab = getSupportActionBar();
        // Enable the Up button
        ab.setDisplayHomeAsUpEnabled(true);*/

        //getSupportActionBar().setDisplayShowTitleEnabled(false);

        getSupportActionBar().setBackgroundDrawable(new ColorDrawable(Color.parseColor( "#4285F4")));

        String title=getSupportActionBar().getTitle().toString();
        SpannableString s = new SpannableString(title);
        s.setSpan(new ForegroundColorSpan(Color.WHITE), 0, title.length(), Spannable.SPAN_EXCLUSIVE_EXCLUSIVE);
        getSupportActionBar().setTitle(s);
        loadMaXacThuc();


        lstDanhSachTaiKhoan.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {

            }
        });


        FloatingActionButton fab = (FloatingActionButton) findViewById(R.id.btnThemTaiKhoan);
        fab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                /*Intent intent=new Intent(HienThiCodeXacThucActivity.this,ThemTaiKhoanActivity.class);
                startActivity(intent);*/

                final Dialog dialog = new Dialog(context);
                dialog.getWindow();
                dialog.requestWindowFeature(Window.FEATURE_NO_TITLE);
                dialog.setContentView(R.layout.custom_dialog_them_tai_khoan);

                WindowManager.LayoutParams lp = new WindowManager.LayoutParams();
                lp.copyFrom(dialog.getWindow().getAttributes());
                lp.width = WindowManager.LayoutParams.MATCH_PARENT;
                lp.gravity = Gravity.BOTTOM;


                Button btnQuetMaQR=(Button)dialog.findViewById(R.id.btnQuetMaQR);
                Button btnNhapMaDuocCungCap=(Button)dialog.findViewById(R.id.btnNhapMaDuocCungCap);

                btnQuetMaQR.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View v) {
                        ConnectivityManager connectivityManager=(ConnectivityManager)getSystemService(CONNECTIVITY_SERVICE);
                        if(!connectivityManager.getNetworkInfo(ConnectivityManager.TYPE_WIFI).isConnected() && !connectivityManager.getNetworkInfo(ConnectivityManager.TYPE_MOBILE).isConnected()){
                            Toast.makeText(getBaseContext(),"Tính năng này cần phải có kết nối Internet.",Toast.LENGTH_LONG).show();
                            return;
                        }
                        Intent intent=new Intent(HienThiCodeXacThucActivity.this, QuetMaQRActivity.class);
                        startActivity(intent);
                    }
                });

                btnNhapMaDuocCungCap.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View v) {
                        ConnectivityManager connectivityManager=(ConnectivityManager)getSystemService(CONNECTIVITY_SERVICE);
                        if(!connectivityManager.getNetworkInfo(ConnectivityManager.TYPE_WIFI).isConnected() && !connectivityManager.getNetworkInfo(ConnectivityManager.TYPE_MOBILE).isConnected()){
                            Toast.makeText(getBaseContext(),"Tính năng này cần phải có kết nối Internet.",Toast.LENGTH_LONG).show();
                            return;
                        }
                        Intent intent=new Intent(HienThiCodeXacThucActivity.this,NhapMaThuCongActivity.class);
                        startActivity(intent);
                    }
                });

                dialog.show();
                dialog.getWindow().setAttributes(lp);
            }
        });


    }
    public  void loadMaXacThuc(){
        layMaXacThuc();
        Date now=new Date(System.currentTimeMillis()+getSharedPreferences("DongBoThoiGian",MODE_PRIVATE).getLong("ThoiGianChenhLech",0));
        giay= now.getSeconds();
        progress=giay*5/3;
        timer1=new CountDownTimer(61000-(1000*giay),300) {
            @Override
            public void onTick(long millisUntilFinished) {
                progress+=0.5;
                progressBar.setProgress(progress %100);
            }

            @Override
            public void onFinish() {
                progress=1;
                layMaXacThuc();
                timer2.start();
            }
        };
        timer1.start();


        timer2=new CountDownTimer(60000,300) {
            @Override
            public void onTick(long millisUntilFinished) {
                progress+=0.5;
                progressBar.setProgress(progress %100);

                //progressBar.setProgressWithAnimation(100, animationDuration);
                // 2500ms = 2,5s
                //Toast.makeText(getApplication(), "Phuc20cm",Toast.LENGTH_LONG).show();
            }

            @Override
            public void onFinish() {
                progress=1;
                layMaXacThuc();
                timer2.start();
            }
        };
    }



    public void layMaXacThuc(){

        dsTaiKhoan.clear();
        SharedPreferences pre=getSharedPreferences("DanhSachTaiKhoan",MODE_PRIVATE);
        Map<String, ?> allEntries = pre.getAll();
        for (Map.Entry<String, ?> entry : allEntries.entrySet()) {
            String email=entry.getKey();
            String ten=entry.getValue().toString().split("#")[0];
            String token=entry.getValue().toString().split("#")[1];

            TaiKhoan tungTaiKhoan=new TaiKhoan();
            tungTaiKhoan.setEmail(email);
            tungTaiKhoan.setTenTaiKhoan(ten);
            String maXacThuc="_ _ _ _ _ _";
            try {
                long timeMillis=System.currentTimeMillis()+getSharedPreferences("DongBoThoiGian",MODE_PRIVATE).getLong("ThoiGianChenhLech",0);
                maXacThuc=HOTPAlgorithm.GetSecurityCode(token,timeMillis);
            } catch (NoSuchAlgorithmException e) {
                e.printStackTrace();
            } catch (InvalidKeyException e) {
                e.printStackTrace();
            }
            tungTaiKhoan.setMaXacThuc(maXacThuc);

            dsTaiKhoan.add(tungTaiKhoan);
        }
        adapter=new HienThiMaXacThucAdapter(HienThiCodeXacThucActivity.this,dsTaiKhoan);
        lstDanhSachTaiKhoan.setAdapter(adapter);

        k++;
    }
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater inflater=getMenuInflater();
        inflater.inflate(R.menu.menu_chung,menu);
        return super.onCreateOptionsMenu(menu);
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            case R.id.option_cai_dat:
                Intent intent_cai_dat = new Intent(HienThiCodeXacThucActivity.this, CaiDatActivity.class);
                startActivity(intent_cai_dat);
                //Toast.makeText(getApplicationContext(),"Mới nhấp cài đặt",Toast.LENGTH_LONG).show();
                return true;
            case R.id.option_cach_thuc_hoat_dong:
                Intent intent_cach_thuc_hoat_dong = new Intent(HienThiCodeXacThucActivity.this, HowItWorksActivity.class);
                startActivity(intent_cach_thuc_hoat_dong);
                //Toast.makeText(getApplicationContext(),"Mới nhấp cách thức hoạt động",Toast.LENGTH_LONG).show();
                return true;
            case R.id.option_tro_giup_va_phan_hoi:
                Intent intent_tro_giup_va_phan_hoi = new Intent(HienThiCodeXacThucActivity.this, TroGiupVaPhanHoiActivity.class);
                startActivity(intent_tro_giup_va_phan_hoi);
                //Toast.makeText(getApplicationContext(),"Mới nhấp trợ giúp và phản hồi",Toast.LENGTH_LONG).show();
                return true;
            default:
                this.onBackPressed();
                return true;
        }
    }

    @Override
    public void onCreateContextMenu(ContextMenu menu, View v, ContextMenu.ContextMenuInfo menuInfo) {
        super.onCreateContextMenu(menu, v, menuInfo);
        AdapterView.AdapterContextMenuInfo info;
        try {
            // Casts the incoming data object into the type for AdapterView objects.
            info = (AdapterView.AdapterContextMenuInfo) menuInfo;
        } catch (ClassCastException e) {
            // If the menu object can't be cast, logs an error.
            return;
        }
        menu.setHeaderTitle(dsTaiKhoan.get(info.position).getEmail());

        if(v.getId()==R.id.lstDanhSachTaiKhoan){
            MenuInflater inflater=getMenuInflater();
            inflater.inflate(R.menu.context_menu_chon_tai_khoan,menu);
        }
    }

    @Override
    public boolean onContextItemSelected(MenuItem item) {
        final AdapterView.AdapterContextMenuInfo info=(AdapterView.AdapterContextMenuInfo)item.getMenuInfo();

        switch (item.getItemId()){
            case R.id.edit:
                dialogDoiTen doiTen=new dialogDoiTen();
                //Tạo bundle để truyền dữ liệu vào dialog
                Bundle args=new Bundle();
                args.putString("TenTaiKhoan",dsTaiKhoan.get(info.position).getTenTaiKhoan());
                args.putString("MaTaiKhoan",dsTaiKhoan.get(info.position).getEmail());
                doiTen.setArguments(args);
                doiTen.show(getSupportFragmentManager(),"nhapten");
                return true;
            case R.id.delete:
                DialogInterface.OnClickListener dialogClickListener = new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        switch (which){
                            case DialogInterface.BUTTON_POSITIVE:
                                secretKey=getSharedPreferences("DanhSachTaiKhoan",MODE_PRIVATE).getString(dsTaiKhoan.get(info.position).getEmail(),"").split("#")[1];
                                Retrofit retrofit = new Retrofit.Builder()
                                        .baseUrl("http://2stepauthentication.azurewebsites.net")
                                        // Sử dụng GSON cho việc parse và maps JSON data tới Object
                                        .addConverterFactory(GsonConverterFactory.create())
                                        .build();

                                // Khởi tạo các cuộc gọi cho Retrofit 2.0
                                DangNhapAPI API = retrofit.create(DangNhapAPI.class);

                                Call<TaiKhoanDangNhap> call = API.loadTaiKhoan(secretKey);
                                // Cuộc gọi bất đồng bọ (chạy dưới background)
                                call.enqueue(HienThiCodeXacThucActivity.this);
                                break;

                            case DialogInterface.BUTTON_NEGATIVE:
                                //No button clicked
                                break;
                        }
                    }
                };

                AlertDialog.Builder builder = new AlertDialog.Builder(HienThiCodeXacThucActivity.this);
                builder.setMessage("Bạn có chắc muốn xóa tài khoản "+dsTaiKhoan.get(info.position).getEmail()+"?").setPositiveButton("Đồng ý", dialogClickListener)
                        .setNegativeButton("Hủy", dialogClickListener).show();
                return true;

            default:
                return super.onContextItemSelected(item);
        }

    }


    @Override
    protected void onPause() {
        timer1.cancel();
        timer2.cancel();
        timer1=null;
        timer2=null;

        super.onPause();

    }

    @Override
    protected void onStop() {
        Log.d("trangthai","stop");
        super.onStop();

    }

    @Override
    protected void onRestart() {
        Log.d("trangthai","restart");
        loadMaXacThuc();
        super.onRestart();
    }

    @Override
    public void onResponse(Response<TaiKhoanDangNhap> response, Retrofit retrofit) {
        if(response.body().getLoginState()==true){
            Toast.makeText(this,"Tài khoản này chưa dừng sử dụng dịch vụ trên service nên không thể xóa.", Toast.LENGTH_LONG).show();
        }
        else if(!response.body().getUsername().equals("")){
            SharedPreferences pre=getSharedPreferences("DanhSachTaiKhoan",MODE_PRIVATE);
            SharedPreferences.Editor edit=pre.edit();
            edit.remove(response.body().getUsername());
            edit.commit();
            Toast.makeText(this,"Xóa tài khoản thành công.",Toast.LENGTH_LONG).show();
            finish();
            startActivity(getIntent());
        }else{
            Toast.makeText(this,"Xóa tài khoản thất bại.",Toast.LENGTH_LONG).show();
        }

    }

    @Override
    public void onFailure(Throwable t) {
        Toast.makeText(this,"Không thể kết nối tới service để xóa tài khoản, vui lòng thử lại sau.",Toast.LENGTH_LONG).show();
    }

    //2 class này phục vụ cho retrofit
    public class TaiKhoanDangNhap{
        private String username;
        private Boolean loginState;

        public String getUsername() {
            return username;
        }

        public void setUsername(String username) {
            this.username = username;
        }

        public Boolean getLoginState() {
            return loginState;
        }

        public void setLoginState(Boolean loginState) {
            this.loginState = loginState;
        }
    }
    public interface DangNhapAPI{
        @GET("/api/android/login/{secretKey}")
        Call<TaiKhoanDangNhap> loadTaiKhoan(@Query("secretKey") String secretKey);
    }
}
