const express = require('express');
const bodyParser = require('body-parser');
const nodemailer = require('nodemailer');

const app = express();
const port = 3000; // Chọn một cổng phù hợp

app.use(bodyParser.urlencoded({ extended: false }));
app.use(bodyParser.json());

// API endpoint để nhận yêu cầu gửi email
app.post('/send-email', (req, res) => {
    const { name, email, message } = req.body;

    // Tạo một tài khoản email để gửi email (cần cấu hình thêm)
    const transporter = nodemailer.createTransport({
        service: 'Gmail',
        auth: {
            user: 'your-email@gmail.com',
            pass: 'your-email-password',
        },
    });

    // Thông tin email
    const mailOptions = {
        from: 'youremail@gmail.com',
        to: 'namdzvpp@gmail.com', // Địa chỉ email của admin
        subject: 'Thông tin từ biểu mẫu liên hệ',
        text: `Tên: ${name}\nEmail: ${email}\nNội dung: ${message}`,
    };

    // Gửi email
    transporter.sendMail(mailOptions, (error, info) => {
        if (error) {
            console.error(error);
            res.status(500).json({ message: 'Gửi email thất bại.' });
        } else {
            console.log('Email sent: ' + info.response);
            res.status(200).json({ message: 'Gửi email thành công.' });
        }
    });
});

app.listen(port, () => {
    console.log(`Máy chủ đang chạy trên cổng ${port}`);
});