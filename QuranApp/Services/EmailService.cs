using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Configuration;

namespace QuranApp.Services
{
    public class EmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendWelcomeEmailAsync(string toEmail, string fullName)
        {
            var fromEmail = _config["EmailSettings:FromEmail"];
            var appPassword = _config["EmailSettings:AppPassword"];
            var displayName = _config["EmailSettings:DisplayName"];

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(displayName, fromEmail));
            message.To.Add(new MailboxAddress(fullName, toEmail));
            message.Subject = "Welcome to QuranApp! 🕌";

            message.Body = new TextPart("html")
            {
              Text = $@"

<div style='background:#eef2f7;
            padding:40px 0;
            font-family:Poppins,Segoe UI,Arial,sans-serif;'>

    <table align='center'
           width='700'
           cellpadding='0'
           cellspacing='0'
           style='background:white;
                  border-radius:24px;
                  overflow:hidden;
                  box-shadow:0 10px 40px rgba(0,0,0,0.08);'>

        <!-- TOP BANNER -->
        <tr>
            <td style='background:url(https://images.unsplash.com/photo-1542816417-0983670d7b4b?q=80&w=1200&auto=format&fit=crop);
                       background-size:cover;
                       background-position:center;
                       padding:80px 40px;
                       text-align:center;'>

                <div style='background:rgba(0,0,0,0.55);
                            padding:35px;
                            border-radius:20px;
                            backdrop-filter:blur(6px);'>

                    <h1 style='margin:0;
                               color:white;
                               font-size:42px;
                               font-weight:700;'>

                        🕌 QuranApp
                    </h1>

                    <p style='color:#e0f2e9;
                              font-size:18px;
                              margin-top:12px;'>

                        Your Complete Islamic Companion
                    </p>

                </div>

            </td>
        </tr>

        <!-- CONTENT -->
        <tr>
            <td style='padding:50px 45px;'>

                <p style='font-size:16px;
                          color:#777;
                          margin-top:0;'>

                    ASSALAMU ALAIKUM
                </p>

                <h2 style='font-size:34px;
                           color:#1f2937;
                           margin-top:10px;'>

                    Welcome, {fullName}! 👋
                </h2>

                <p style='font-size:17px;
                          line-height:1.9;
                          color:#4b5563;'>

                    Your QuranApp account has been successfully created.
                    We are honored to have you join our growing Islamic
                    digital community dedicated to faith, learning,
                    spirituality, and daily worship.
                </p>

                <!-- FEATURES -->
                <table width='100%'
                       cellpadding='0'
                       cellspacing='0'
                       style='margin-top:35px;'>

                    <tr>

                        <td width='48%'
                            style='background:#f8fafc;
                                   border-radius:18px;
                                   padding:25px;
                                   border:1px solid #e5e7eb;'>

                            <div style='font-size:42px;'>📖</div>

                            <h3 style='margin:15px 0 10px 0;
                                       color:#111827;'>

                                Holy Quran
                            </h3>

                            <p style='color:#6b7280;
                                      line-height:1.7;
                                      font-size:14px;'>

                                Read the complete Quran with English,
                                Urdu & Persian translations and advanced search.
                            </p>

                        </td>

                        <td width='4%'></td>

                        <td width='48%'
                            style='background:#f8fafc;
                                   border-radius:18px;
                                   padding:25px;
                                   border:1px solid #e5e7eb;'>

                            <div style='font-size:42px;'>🕋</div>

                            <h3 style='margin:15px 0 10px 0;
                                       color:#111827;'>

                                Prayer & Qibla
                            </h3>

                            <p style='color:#6b7280;
                                      line-height:1.7;
                                      font-size:14px;'>

                                Accurate prayer timings,
                                Qibla direction, and live Salah countdown.
                            </p>

                        </td>

                    </tr>

                </table>

                <!-- SECOND ROW -->
                <table width='100%'
                       cellpadding='0'
                       cellspacing='0'
                       style='margin-top:18px;'>

                    <tr>

                        <td width='48%'
                            style='background:#f8fafc;
                                   border-radius:18px;
                                   padding:25px;
                                   border:1px solid #e5e7eb;'>

                            <div style='font-size:42px;'>📿</div>

                            <h3 style='margin:15px 0 10px 0;
                                       color:#111827;'>

                                Daily Dhikr
                            </h3>

                            <p style='color:#6b7280;
                                      line-height:1.7;
                                      font-size:14px;'>

                                Use Tasbih Counter and explore
                                the beautiful 99 Names of Allah.
                            </p>

                        </td>

                        <td width='4%'></td>

                        <td width='48%'
                            style='background:#f8fafc;
                                   border-radius:18px;
                                   padding:25px;
                                   border:1px solid #e5e7eb;'>

                            <div style='font-size:42px;'>🌙</div>

                            <h3 style='margin:15px 0 10px 0;
                                       color:#111827;'>

                                Islamic Calendar
                            </h3>

                            <p style='color:#6b7280;
                                      line-height:1.7;
                                      font-size:14px;'>

                                Track Hijri dates,
                                Islamic events, and important occasions.
                            </p>

                        </td>

                    </tr>

                </table>

                <!-- AYAH BOX -->
                <div style='margin-top:40px;
                            background:linear-gradient(135deg,#0f172a,#14532d);
                            border-radius:22px;
                            padding:35px;
                            text-align:center;'>

                    <p style='font-size:34px;
                              color:#ffffff;
                              line-height:1.9;
                              margin:0;
                              font-family:Traditional Arabic;'>

                        بِسْمِ اللَّهِ الرَّحْمَٰنِ الرَّحِيمِ
                    </p>

                    <p style='color:#d1fae5;
                              margin-top:15px;
                              font-size:15px;'>

                        In the name of Allah,
                        the Most Gracious, the Most Merciful
                    </p>

                </div>

                <p style='font-size:16px;
                          line-height:1.9;
                          color:#4b5563;
                          margin-top:35px;'>

                    We pray QuranApp becomes a source of peace,
                    guidance, and barakah in your life.
                    May Allah bless your journey and strengthen
                    your connection with the Quran every day.
                </p>

                <!-- BUTTON -->
                <div style='text-align:center;
                            margin-top:40px;'>

                    <a href='https://quranapp-production-759b.up.railway.app/'
                       style='background:linear-gradient(135deg,#16a34a,#15803d);
                              color:white;
                              padding:18px 45px;
                              border-radius:60px;
                              text-decoration:none;
                              font-size:16px;
                              font-weight:600;
                              display:inline-block;
                              box-shadow:0 8px 25px rgba(22,163,74,0.35);'>

                        Open QuranApp →
                    </a>

                </div>

                <!-- SIGNATURE -->
                <div style='margin-top:50px;
                            border-top:1px solid #e5e7eb;
                            padding-top:30px;'>

                    <p style='font-size:16px;
                              color:#374151;
                              line-height:1.8;'>

                        Warm Regards,<br/><br/>

                        <strong style='color:#15803d;
                                       font-size:18px;'>

                            The QuranApp Team
                        </strong><br/>

                        Abdul Muneeb Butt & M.Qasim<br/>
                        Air University Kharian Campus
                    </p>

                </div>

            </td>
        </tr>

        <!-- FOOTER -->
        <tr>
            <td style='background:#111827;
                       padding:28px;
                       text-align:center;'>

                <p style='margin:0;
                          color:#f9fafb;
                          font-size:14px;'>

                    © 2026 QuranApp — All Rights Reserved
                </p>

                <p style='margin-top:10px;
                          color:#9ca3af;
                          font-size:12px;'>

                    BS Computer Science — Visual Programming Project
                </p>

            </td>
        </tr>

    </table>

</div>

"    };

            using var client = new SmtpClient();
            await client.ConnectAsync("smtp.gmail.com", 587,
                MailKit.Security.SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(fromEmail, appPassword);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}