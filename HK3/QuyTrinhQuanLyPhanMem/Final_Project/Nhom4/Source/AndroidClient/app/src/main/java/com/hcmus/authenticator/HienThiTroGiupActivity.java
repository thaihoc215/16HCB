package com.hcmus.authenticator;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.webkit.WebView;

public class HienThiTroGiupActivity extends AppCompatActivity {

    WebView wvHienThiTroGiup;
    Intent intent;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_hien_thi_tro_giup);
        intent=getIntent();
        String link=intent.getStringExtra("link");
        wvHienThiTroGiup=(WebView)findViewById(R.id.wvHienThiTroGiup);
        wvHienThiTroGiup.loadUrl(link);

    }
}
