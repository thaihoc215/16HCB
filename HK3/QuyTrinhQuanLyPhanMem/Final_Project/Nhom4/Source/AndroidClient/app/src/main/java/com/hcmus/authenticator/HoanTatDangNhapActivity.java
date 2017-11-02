package com.hcmus.authenticator;

import android.content.Intent;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;
import android.widget.ListView;

import java.util.ArrayList;

public class HoanTatDangNhapActivity extends AppCompatActivity {

    Button btnXong;
    ListView lstMaXacThuc;
    ArrayList<TaiKhoan> dsTaiKhoan=new ArrayList<TaiKhoan>();
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_hoan_tat_dang_nhap);

        getSupportActionBar().setBackgroundDrawable(new ColorDrawable(Color.parseColor( "#4285F4")));

        btnXong=(Button)findViewById(R.id.btnXong);

        btnXong.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent=new Intent(HoanTatDangNhapActivity.this,HienThiCodeXacThucActivity.class);
                startActivity(intent);
            }
        });
    }
}
