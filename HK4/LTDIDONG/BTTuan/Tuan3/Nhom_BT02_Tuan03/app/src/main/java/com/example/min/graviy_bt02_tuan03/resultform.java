package com.example.min.graviy_bt02_tuan03;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.TextView;
import  android.widget.Toast;
import android.widget.Button;
import java.text.ParseException;
public class resultform extends AppCompatActivity {

    private TextView lblDisplayUsername, lblDisplayPassword, lblDisplayHobbies,
            lblDisplayBirthday, lblDisplayGender;
    private Button btnExit;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.resultform);
        Bundle bd = getIntent().getExtras();
        String password = bd.getString("password");
        String showPass = "";
        for(int i = 0; i < password.length(); i++){
            showPass += "*";
        }
        lblDisplayUsername = (TextView) findViewById(R.id.lblDisplayUsername);
        lblDisplayPassword = (TextView)findViewById((R.id.lblDisplayPassword));
        lblDisplayHobbies = (TextView)findViewById(R.id.lblDisplayHobbies);
        lblDisplayBirthday = (TextView)findViewById(R.id.lblDisplayBirthday);
        lblDisplayGender = (TextView)findViewById(R.id.lblDisplayGender);
        lblDisplayUsername.setText(bd.getString("username"));
        lblDisplayPassword.setText(showPass);
        lblDisplayHobbies.setText(bd.getString("hobbies"));
        lblDisplayBirthday.setText(bd.getString("birthday"));
        lblDisplayGender.setText(bd.getString("gender"));
        btnExit = (Button)findViewById(R.id.btnExit);
        btnExit.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                closeApp(view);
            }
        });
    }

    public void closeApp(View view){
        finish();
        android.os.Process.killProcess(android.os.Process.myPid());
        System.exit(1);
    }
}
