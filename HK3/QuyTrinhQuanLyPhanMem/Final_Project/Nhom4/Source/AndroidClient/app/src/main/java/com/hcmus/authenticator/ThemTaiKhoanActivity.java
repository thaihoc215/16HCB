package com.hcmus.authenticator;

import android.content.Intent;
import android.content.SharedPreferences;
import android.net.ConnectivityManager;
import android.os.Bundle;
import android.support.v7.app.ActionBar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.Toast;

import com.google.zxing.Result;

import me.dm7.barcodescanner.zxing.ZXingScannerView;
import retrofit.Call;
import retrofit.Callback;
import retrofit.GsonConverterFactory;
import retrofit.Response;
import retrofit.Retrofit;
import retrofit.http.GET;
import retrofit.http.Query;

public class ThemTaiKhoanActivity extends AppCompatActivity {

    Button btnQuetQR, btnNhapMaThuCong;
    ImageView imvThemTaiKhoan;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_them_tai_khoan);
        Toolbar myToolbar=(Toolbar)findViewById(R.id.my_toolbar);
        setSupportActionBar(myToolbar);

        // Get a support ActionBar corresponding to this toolbar
        ActionBar ab = getSupportActionBar();
        // Enable the Up button
        ab.setDisplayHomeAsUpEnabled(true);

        getSupportActionBar().setDisplayShowTitleEnabled(false);

        imvThemTaiKhoan=(ImageView)findViewById(R.id.imvTaiKhoan);
        btnQuetQR=(Button)findViewById(R.id.btnQuetQR);
        btnNhapMaThuCong=(Button)findViewById(R.id.btnNhapMaThuCong);
        btnQuetQR.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                ConnectivityManager connectivityManager=(ConnectivityManager)getSystemService(CONNECTIVITY_SERVICE);
                if(!connectivityManager.getNetworkInfo(ConnectivityManager.TYPE_WIFI).isConnected() && !connectivityManager.getNetworkInfo(ConnectivityManager.TYPE_MOBILE).isConnected()){
                    Toast.makeText(getBaseContext(),"Tính năng này cần phải có kết nối Internet.",Toast.LENGTH_LONG).show();
                    return;
                }
                Intent intent=new Intent(ThemTaiKhoanActivity.this,QuetMaQRActivity.class);
                startActivity(intent);
            }
        });

        btnNhapMaThuCong.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                ConnectivityManager connectivityManager=(ConnectivityManager)getSystemService(CONNECTIVITY_SERVICE);
                if(!connectivityManager.getNetworkInfo(ConnectivityManager.TYPE_WIFI).isConnected() && !connectivityManager.getNetworkInfo(ConnectivityManager.TYPE_MOBILE).isConnected()){
                    Toast.makeText(getBaseContext(),"Tính năng này cần phải có kết nối Internet.",Toast.LENGTH_LONG).show();
                    return;
                }
                Intent intent=new Intent(ThemTaiKhoanActivity.this,NhapMaThuCongActivity.class);
                startActivity(intent);
            }
        });
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater inflater=getMenuInflater();
        inflater.inflate(R.menu.menu_chung,menu);
        return super.onCreateOptionsMenu(menu);
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()){
            case R.id.option_cai_dat:
                Intent intent_cai_dat=new Intent(ThemTaiKhoanActivity.this,CaiDatActivity.class);
                startActivity(intent_cai_dat);
                return true;
            case R.id.option_cach_thuc_hoat_dong:
                Intent intent_cach_thuc_hoat_dong=new Intent(ThemTaiKhoanActivity.this,HowItWorksActivity.class);
                startActivity(intent_cach_thuc_hoat_dong);
                return true;
            case R.id.option_tro_giup_va_phan_hoi:
                Intent intent_tro_giup_va_phan_hoi=new Intent(ThemTaiKhoanActivity.this,TroGiupVaPhanHoiActivity.class);
                startActivity(intent_tro_giup_va_phan_hoi);
                return true;
            default: return true;
        }
    }

    @Override
    protected void onPause() {
        super.onPause();
    }
}
