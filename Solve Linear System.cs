using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Linear_Project
{
    public partial class Solve_Linear_System : Form
    {
        int NumOfEquations = 0;

        public Solve_Linear_System(int num_of_equations)
        {
            InitializeComponent();
            NumOfEquations = num_of_equations;

            // Initially hide the RichTextBox for results
            rtbResult.Visible = false;

            // Parse the number of equations
            if (NumOfEquations > 0)
            {
                GenerateAugmentedMatrix();
            }
            else
            {
                MessageBox.Show("Please enter a valid positive integer for the number of equations.", "Invalid Input",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerateAugmentedMatrix()
        {
            panMatrix.Controls.Clear();  // Clear any previous controls
            int totalColumns = NumOfEquations + 1;  // Extra column for augmented part
            int textBoxSize = 40;  // Size of each TextBox

            for (int row = 0; row < NumOfEquations; row++)
            {
                for (int col = 0; col < totalColumns; col++)
                {
                    // Create a new TextBox for each cell in the matrix
                    TextBox txtCell = new TextBox
                    {
                        Size = new Size(textBoxSize, textBoxSize),
                        Location = new Point(col * textBoxSize, row * textBoxSize),
                        TextAlign = HorizontalAlignment.Center,
                        Name = $"txt_{row}_{col}"  // Assign a unique name to retrieve values later
                    };

                    // Add the TextBox to the panel
                    panMatrix.Controls.Add(txtCell);
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Retrieve values from the matrix
            double[,] matrix = new double[NumOfEquations, NumOfEquations + 1];
            try
            {
                for (int i = 0; i < NumOfEquations; i++)
                {
                    for (int j = 0; j <= NumOfEquations; j++)
                    {
                        TextBox txtBox = panMatrix.Controls.Find($"txt_{i}_{j}", true).FirstOrDefault() as TextBox;
                        if (txtBox != null)
                        {
                            matrix[i, j] = double.Parse(txtBox.Text);  // Parse the input to double
                        }
                    }
                }

                // Perform Gaussian elimination and display result
                PerformGaussJordanElimination(matrix, NumOfEquations);

                // Maximize the form window
                this.WindowState = FormWindowState.Maximized;

                // Hide all other controls
                panMatrix.Visible = false;
                btnSubmit.Visible = false;

                // Make rtbResult fill the entire form
                rtbResult.Dock = DockStyle.Fill;
                rtbResult.Visible = true; // Show rtbResult after calculations
            }
            catch (FormatException)
            {
                MessageBox.Show("Please ensure all inputs are valid numbers.", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PerformGaussJordanElimination(double[,] matrix, int n)
        {
            rtbResult.Clear(); // Clear any previous results
            rtbResult.Visible = true; // Ensure rtbResult is visible when displaying results

            // Forward elimination to form a diagonal matrix with 1's on the diagonal
            for (int i = 0; i < n; i++)
            {
                // Step 1: Pivot selection - Find the maximum element in the current column
                int maxRow = i;
                for (int k = i + 1; k < n; k++)
                {
                    if (Math.Abs(matrix[k, i]) > Math.Abs(matrix[maxRow, i]))
                    {
                        maxRow = k;
                    }
                }

                // Step 2: Swap rows if needed to bring the maximum element to the pivot position
                if (maxRow != i)
                {
                    rtbResult.AppendText($"Swapping row {i + 1} with row {maxRow + 1} to use the largest pivot element.\n");
                    for (int k = 0; k <= n; k++)
                    {
                        double temp = matrix[maxRow, k];
                        matrix[maxRow, k] = matrix[i, k];
                        matrix[i, k] = temp;
                    }
                    PrintMatrix(matrix, n);  // Show matrix after swapping
                }

                // Step 3: Normalize the pivot row (make the pivot element equal to 1)
                double pivot = matrix[i, i];
                if (pivot != 0)
                {
                    rtbResult.AppendText($"Normalizing row {i + 1} by dividing by {pivot:F2}.\n");
                    for (int j = 0; j <= n; j++)
                    {
                        matrix[i, j] /= pivot;
                    }
                    PrintMatrix(matrix, n);  // Show matrix after normalization
                }

                // Step 4: Make all other entries in the current column 0
                for (int k = 0; k < n; k++)
                {
                    if (k != i)  // Skip the pivot row
                    {
                        double factor = matrix[k, i];
                        rtbResult.AppendText($"Making element in row {k + 1}, column {i + 1} zero by subtracting {factor:F2} " +
                            $"* row {i + 1}.\n");
                        for (int j = 0; j <= n; j++)
                        {
                            matrix[k, j] -= factor * matrix[i, j];
                        }
                        PrintMatrix(matrix, n);  // Show matrix after making elements zero
                    }
                }
            }

            // Display the final solution
            rtbResult.AppendText("Solution:\n");
            for (int i = 0; i < n; i++)
            {
                rtbResult.AppendText($"x{i + 1} = {matrix[i, n]:F2}\n");
            }
        }
        private void PrintMatrix(double[,] matrix, int n)
        {
            rtbResult.AppendText("Matrix State:\n");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    rtbResult.AppendText($"{matrix[i, j],10:F2} ");
                }
                rtbResult.AppendText("\n");
            }
            rtbResult.AppendText("-------------------------------------------------------------------------------\n");
        }

        private void Solve_Linear_System_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
