using System.Security.Cryptography;
using System.Text;
using WinTimer = System.Windows.Forms.Timer; // Perbaikan untuk ambiguitas Timer

namespace password_gen
{
    public partial class Form1 : Form
    {
        // Character sets untuk password
        private const string UPPERCASE = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string LOWERCASE = "abcdefghijklmnopqrstuvwxyz";
        private const string NUMBERS = "0123456789";
        private const string SYMBOLS = "!@#$%^&*()_+-=[]{}|;:,.<>?";
        private const string SIMILAR_CHARS = "0O1lI";

        public Form1()
        {
            InitializeComponent();

            // Update strength saat ada perubahan
            numLength.ValueChanged += UpdatePasswordStrength;
            cbUppercase.CheckedChanged += UpdatePasswordStrength;
            cbLowercase.CheckedChanged += UpdatePasswordStrength;
            cbNumbers.CheckedChanged += UpdatePasswordStrength;
            cbSymbols.CheckedChanged += UpdatePasswordStrength;

            numLength.ValueChanged += NumLength_ValueChanged;

            // Menambahkan event handler untuk trackLength_Scroll yang hilang
            trackLength.Scroll += trackLength_Scroll;

            // Perbaikan TextBox untuk scroll horizontal
            SetupPasswordTextBox();

            // Generate password pertama kali
            GeneratePassword();
            UpdatePasswordStrength(null, null);
        }

        // Event handler Form1_Load yang hilang
        private void Form1_Load(object sender, EventArgs e)
        {
            // Inisialisasi tambahan jika diperlukan
            UpdatePasswordStrength(null, null);
        }

        // Event handler trackLength_Scroll yang hilang
        private void trackLength_Scroll(object sender, EventArgs e)
        {
            // Sync trackbar dengan numeric updown
            numLength.Value = trackLength.Value;
            UpdatePasswordStrength(null, null);
        }

        private void SetupPasswordTextBox()
        {
            // Setup untuk scroll horizontal yang proper
            txtPassword.ScrollBars = ScrollBars.Horizontal;
            txtPassword.WordWrap = false;
            txtPassword.AcceptsReturn = false;
            txtPassword.AcceptsTab = false;

            // Event untuk auto-scroll ke kanan saat password baru
            txtPassword.TextChanged += TxtPassword_TextChanged;
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length > 30) // Threshold untuk scrollbar
            {
                txtPassword.SelectionStart = 0;
                txtPassword.ScrollToCaret();
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            GeneratePassword();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPassword.Text))
            {
                Clipboard.SetText(txtPassword.Text);
                MessageBox.Show("Password berhasil disalin ke clipboard!", "Sukses",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Konfirmasi sebelum clear
            DialogResult result = MessageBox.Show(
                "Apakah Anda yakin ingin menghapus password?",
                "Konfirmasi Clear",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2); // Default ke "No"

            if (result == DialogResult.Yes)
            {
                // Clear password
                txtPassword.Clear();

                // Reset progress bar
                progressStrength.Value = 0;
                lblStrength.Text = "Strength: -";
                lblStrength.ForeColor = Color.Gray;

                // Visual feedback untuk button clear
                Color originalColor = btnClear.BackColor;
                btnClear.BackColor = Color.FromArgb(192, 57, 43); // Merah lebih gelap
                btnClear.Text = "Cleared!";

                // Timer untuk reset button (menggunakan alias WinTimer)
                WinTimer resetTimer = new WinTimer();
                resetTimer.Interval = 1000; // 1 detik
                resetTimer.Tick += (s, args) =>
                {
                    btnClear.BackColor = originalColor;
                    btnClear.Text = "Clear";
                    resetTimer.Stop();
                    resetTimer.Dispose();
                };
                resetTimer.Start();

                // Focus ke generate button untuk UX yang baik
                btnGenerate.Focus();
            }
        }

        private void NumLength_ValueChanged(object sender, EventArgs e)
        {
            // Sync numeric updown dengan trackbar
            if (numLength.Value <= trackLength.Maximum)
            {
                trackLength.Value = (int)numLength.Value;
            }

            // Update strength setelah perubahan length
            UpdatePasswordStrength(null, null);
        }

        private void GeneratePassword()
        {
            // Validasi minimal satu checkbox harus dipilih
            if (!cbUppercase.Checked && !cbLowercase.Checked &&
                !cbNumbers.Checked && !cbSymbols.Checked)
            {
                MessageBox.Show("Pilih minimal satu jenis karakter!", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int length = (int)numLength.Value;
            string characterSet = BuildCharacterSet();
            string password = GenerateSecurePassword(characterSet, length);

            txtPassword.Text = password;
            UpdatePasswordStrength(null, null);
        }

        private string BuildCharacterSet()
        {
            StringBuilder charSet = new StringBuilder();

            if (cbUppercase.Checked) charSet.Append(UPPERCASE);
            if (cbLowercase.Checked) charSet.Append(LOWERCASE);
            if (cbNumbers.Checked) charSet.Append(NUMBERS);
            if (cbSymbols.Checked) charSet.Append(SYMBOLS);

            string result = charSet.ToString();

            // Exclude similar characters jika dipilih
            if (cbExcludeSimilar.Checked)
            {
                foreach (char c in SIMILAR_CHARS)
                {
                    result = result.Replace(c.ToString(), "");
                }
            }

            return result;
        }

        private string GenerateSecurePassword(string characterSet, int length)
        {
            if (string.IsNullOrEmpty(characterSet)) return "";

            StringBuilder password = new StringBuilder();

            // Gunakan cryptographically secure random
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] randomBytes = new byte[length];
                rng.GetBytes(randomBytes);

                for (int i = 0; i < length; i++)
                {
                    int index = randomBytes[i] % characterSet.Length;
                    password.Append(characterSet[index]);
                }
            }

            // Pastikan password memenuhi kriteria yang dipilih
            return EnsurePasswordCriteria(password.ToString(), characterSet);
        }

        private string EnsurePasswordCriteria(string password, string characterSet)
        {
            StringBuilder result = new StringBuilder(password);

            // Pastikan setiap jenis karakter yang dipilih ada minimal satu
            if (cbUppercase.Checked && !password.Any(c => UPPERCASE.Contains(c)))
            {
                result[0] = GetRandomChar(UPPERCASE);
            }

            if (cbLowercase.Checked && !password.Any(c => LOWERCASE.Contains(c)))
            {
                int pos = cbUppercase.Checked ? 1 : 0;
                if (pos < result.Length)
                    result[pos] = GetRandomChar(LOWERCASE);
            }

            if (cbNumbers.Checked && !password.Any(c => NUMBERS.Contains(c)))
            {
                int pos = 0;
                if (cbUppercase.Checked) pos++;
                if (cbLowercase.Checked) pos++;
                if (pos < result.Length)
                    result[pos] = GetRandomChar(NUMBERS);
            }

            if (cbSymbols.Checked && !password.Any(c => SYMBOLS.Contains(c)))
            {
                int pos = 0;
                if (cbUppercase.Checked) pos++;
                if (cbLowercase.Checked) pos++;
                if (cbNumbers.Checked) pos++;
                if (pos < result.Length)
                    result[pos] = GetRandomChar(SYMBOLS);
            }

            return result.ToString();
        }

        private char GetRandomChar(string charSet)
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] randomByte = new byte[1];
                rng.GetBytes(randomByte);
                int index = randomByte[0] % charSet.Length;
                return charSet[index];
            }
        }

        private void UpdatePasswordStrength(object sender, EventArgs e)
        {
            int score = CalculatePasswordStrength();
            progressStrength.Value = Math.Min(score, 100);

            // Update warna berdasarkan kekuatan
            if (score < 30)
            {
                progressStrength.ForeColor = Color.Red;
                lblStrength.Text = "Strength: Weak";
                lblStrength.ForeColor = Color.Red;
            }
            else if (score < 70)
            {
                progressStrength.ForeColor = Color.Orange;
                lblStrength.Text = "Strength: Medium";
                lblStrength.ForeColor = Color.Orange;
            }
            else
            {
                progressStrength.ForeColor = Color.Green;
                lblStrength.Text = "Strength: Strong";
                lblStrength.ForeColor = Color.Green;
            }
        }

        private int CalculatePasswordStrength()
        {
            int score = 0;
            int length = (int)numLength.Value;

            // Skor berdasarkan panjang
            score += Math.Min(length * 2, 50);

            // Skor berdasarkan variasi karakter
            int charTypes = 0;
            if (cbUppercase.Checked) charTypes++;
            if (cbLowercase.Checked) charTypes++;
            if (cbNumbers.Checked) charTypes++;
            if (cbSymbols.Checked) charTypes++;

            score += charTypes * 10;

            // Bonus untuk kombinasi yang baik
            if (charTypes >= 3 && length >= 12) score += 20;
            if (charTypes == 4 && length >= 16) score += 30;

            return Math.Min(score, 100);
        }

        private void progressStrength_Click(object sender, EventArgs e)
        {
            // Event handler kosong - bisa digunakan untuk menampilkan detail strength
        }
    }
}