package com.hcmus.authenticator;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        if(getSharedPreferences("DanhSachTaiKhoan",MODE_PRIVATE).getAll().size()==0){
            Intent i=new Intent(MainActivity.this,BatDauActivity.class);
            startActivity(i);
        }
        else {
            Intent i=new Intent(MainActivity.this,HienThiCodeXacThucActivity.class);
            startActivity(i);
        }
    }
}
