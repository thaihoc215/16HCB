package com.hcmus.authenticator;

import android.content.Intent;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.net.Uri;
import android.support.v7.app.ActionBar;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ListView;
import android.widget.Toast;

import java.util.ArrayList;


public class TroGiupVaPhanHoiActivity extends AppCompatActivity {
    ListView lstPhoBien;
    ArrayList<String> dsPhoBien=new ArrayList<String>();
    Intent intent;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_tro_giup_va_phan_hoi);

        ActionBar ab = getSupportActionBar();
        // Enable the Up button
        ab.setDisplayHomeAsUpEnabled(true);

        getSupportActionBar().setBackgroundDrawable(new ColorDrawable(Color.parseColor( "#4285F4")));

        lstPhoBien=(ListView)findViewById(R.id.lstTroGiupPhoBien);


        dsPhoBien.add("Bật xác minh 2 bước");
        dsPhoBien.add("Tắt xác minh 2 bước");
        dsPhoBien.add("Đăng nhập bằng xác minh 2 bước");
        dsPhoBien.add("Cài đặt xác minh 2 bước");
        dsPhoBien.add("Sự cố thường gặp với xác minh 2 bước");
        dsPhoBien.add("(Các) tài khoản của tôi đã biến mất");
        dsPhoBien.add("Xóa mật khẩu ứng dụng");

        ArrayAdapter<String> adapterPhoBien=new ArrayAdapter<String>(this,android.R.layout.simple_list_item_1,android.R.id.text1,  dsPhoBien);
        lstPhoBien.setAdapter(adapterPhoBien);

        intent=new Intent(TroGiupVaPhanHoiActivity.this,HienThiTroGiupActivity.class);

        lstPhoBien.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                switch(position){
                    case 0:
                        intent.putExtra("link","https://support.google.com/accounts/answer/185839?hl=vi");
                        startActivity(intent);
                        break;
                    case 1:
                        intent.putExtra("link","https://support.google.com/accounts/answer/1064203?hl=vi");
                        startActivity(intent);
                        break;
                    case 2:
                        intent.putExtra("link","https://support.google.com/accounts/answer/1085463?hl=vi");
                        startActivity(intent);
                        break;
                    case 3:
                        intent.putExtra("link","https://support.google.com/accounts/answer/1066447?hl=vi");
                        startActivity(intent);
                        break;
                    case 4:
                        intent.putExtra("link","https://support.google.com/accounts/answer/185834?hl=vi");
                        startActivity(intent);
                        break;
                    case 5:
                        intent.putExtra("link","https://support.google.com/accounts/answer/3376859?hl=vi");
                        startActivity(intent);
                        break;
                    case 6:
                        intent.putExtra("link","https://support.google.com/accounts/answer/1070455?hl=vi");
                        startActivity(intent);
                        break;
                }
            }
        });
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        onBackPressed();
        return true;
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        return true;
    }
}
