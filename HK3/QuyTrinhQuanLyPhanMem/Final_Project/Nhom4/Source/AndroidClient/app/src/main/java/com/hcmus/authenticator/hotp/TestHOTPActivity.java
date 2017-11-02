package com.hcmus.authenticator.hotp;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.TextView;

import com.hcmus.authenticator.R;

import java.security.InvalidKeyException;
import java.security.NoSuchAlgorithmException;

public class TestHOTPActivity extends AppCompatActivity {

    EditText txtSecretKey;
    TextView lblSecurityCode;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_test_hotp);

        txtSecretKey = (EditText) findViewById(R.id.txtSecretKey);
        lblSecurityCode = (TextView) findViewById(R.id.lblSecurityCode);

    }

    public void getSecretkey(View view) {
        try {
            String SecurityCode = HOTPAlgorithm.GetSecurityCode(txtSecretKey.getText().toString());
            lblSecurityCode.setText("Security Code: " + SecurityCode);
        } catch (NoSuchAlgorithmException e) {
            lblSecurityCode.setText("Security Code: Error");
            e.printStackTrace();
        } catch (InvalidKeyException e) {
            e.printStackTrace();
            lblSecurityCode.setText("Security Code: Error");
        }
    }
}
