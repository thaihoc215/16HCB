package com.hcmus.authenticator;

import android.content.Intent;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.graphics.drawable.Drawable;
import android.os.Bundle;
import android.support.v4.content.ContextCompat;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;

public class BatDauActivity extends AppCompatActivity {

    Button btnBatDau;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_bat_dau);
        btnBatDau=(Button)findViewById(R.id.btnBatDau);

        Toolbar myToolbar=(Toolbar)findViewById(R.id.my_toolbar);
        setSupportActionBar(myToolbar);
        //set icon cho cái menu.
        //mặc định nó là 3 chấm màu đen
        Drawable drawable = ContextCompat.getDrawable(getApplicationContext(),R.mipmap.icon_option_menu);
        myToolbar.setOverflowIcon(drawable);

        //xóa tiêu đề
        getSupportActionBar().setDisplayShowTitleEnabled(false);
        //set màu nền cho actionbar
        getSupportActionBar().setBackgroundDrawable(new ColorDrawable(Color.parseColor( "#4285F4")));

        btnBatDau.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent=new Intent(BatDauActivity.this,ThemTaiKhoanActivity.class);
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
                Intent intent_cai_dat=new Intent(BatDauActivity.this,CaiDatActivity.class);
                startActivity(intent_cai_dat);
                //Toast.makeText(getApplicationContext(),"Mới nhấp cài đặt",Toast.LENGTH_LONG).show();
                return true;
            case R.id.option_cach_thuc_hoat_dong:
                Intent intent_cach_thuc_hoat_dong=new Intent(BatDauActivity.this,HowItWorksActivity.class);
                startActivity(intent_cach_thuc_hoat_dong);
                //Toast.makeText(getApplicationContext(),"Mới nhấp cách thức hoạt động",Toast.LENGTH_LONG).show();
                return true;
            case R.id.option_tro_giup_va_phan_hoi:
                Intent intent_tro_giup_va_phan_hoi=new Intent(BatDauActivity.this,TroGiupVaPhanHoiActivity.class);
                startActivity(intent_tro_giup_va_phan_hoi);
                //Toast.makeText(getApplicationContext(),"Mới nhấp trợ giúp và phản hồi",Toast.LENGTH_LONG).show();
                return true;
            default:
                this.onBackPressed();
                return true;
        }
    }
}
