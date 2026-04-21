using EduCostCalc.Models;
using EduCostCalc.Services;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using System.Text;

namespace EduCostCalc
{
    public partial class MainForm : Form
    {
        private readonly Company _currentCompany;
        private readonly CostCalculator _calculator;
        private readonly DetailedCostCalculator _detailedCalculator;
        

        public MainForm()
        {
            InitializeComponent();
            _currentCompany = new Company();
            _calculator = new CostCalculator(_currentCompany);
            _detailedCalculator = new DetailedCostCalculator(_currentCompany);

            SetupMainMenu();
            tabControl1.Dock = DockStyle.Fill;

        }

        private void SetupMainMenu()
        {
            var menuStrip = new MenuStrip();
            menuStrip.Dock = DockStyle.Top;
            menuStrip.Font = new Font("Segoe UI", 9F);

            var fileMenu = new ToolStripMenuItem("&Файл");

            var exportItem = new ToolStripMenuItem("Экспорт в CSV", null, (s, e) => BtnExportCsv_Click(this, EventArgs.Empty));
            var importItem = new ToolStripMenuItem("Импорт из CSV", null, (s, e) => BtnImportCsv_Click(this, EventArgs.Empty));

            fileMenu.DropDownItems.Add(exportItem);
            fileMenu.DropDownItems.Add(new ToolStripSeparator());
            fileMenu.DropDownItems.Add(importItem);

            // Пункт "Выход"
            fileMenu.DropDownItems.Add(new ToolStripSeparator());
            var exitItem = new ToolStripMenuItem("Выход", null, (s, e) => Application.Exit());
            fileMenu.DropDownItems.Add(exitItem);

            menuStrip.Items.Add(fileMenu);

            // Добавляем меню на форму (до TabControl, чтобы TabControl сжался)
            this.Controls.Add(menuStrip);
            this.MainMenuStrip = menuStrip;
        }

        // ================= EXPORT LOGIC =================

        private void BtnExportCsv_Click(object sender, EventArgs e)
        {
            try
            {
                // Синхронизируем данные из полей в модель
                SaveFormDataToCompany();
                SaveDetailedFormData();

                using (var saveFileDialog = new SaveFileDialog
                {
                    Filter = "CSV файлы|*.csv|Все файлы|*.*",
                    FileName = $"EduCostCalc_Export_{DateTime.Now:yyyyMMdd_HHmm}.csv",
                    DefaultExt = "csv",
                    Title = "Сохранить расчет в CSV"
                })
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        var csvContent = GenerateCsvContent();
                        // UTF8 с BOM для корректного отображения кириллицы в Excel
                        File.WriteAllText(saveFileDialog.FileName, csvContent, new UTF8Encoding(true));
                        MessageBox.Show("Данные успешно экспортированы!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка экспорта: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerateCsvContent()
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine("Параметр;Значение;Вкладка");

            // Вспомогательная функция форматирования (2 знака, точка как разделитель)
            string F(decimal d) => d.ToString("F2", CultureInfo.InvariantCulture);

            // === ВКЛАДКА 1: Базовые параметры ===
            sb.AppendLine($"Объем выпуска (Q);{F(nudOutputVolume.Value)};1");
            sb.AppendLine($"Цена реализации (P);{F(nudPricePerUnit.Value)};1");
            sb.AppendLine($"Сырье и материалы (ед.);{F(nudRawMaterials.Value)};1");
            sb.AppendLine($"Энергия/транспорт (ед.);{F(nudEnergyTransport.Value)};1");
            sb.AppendLine($"Сдельная ЗП (ед.);{F(nudPieceworkWage.Value)};1");
            sb.AppendLine($"Аренда помещения;{F(nudRent.Value)};1");
            sb.AppendLine($"Амортизация оборудования;{F(nudDepreciation.Value)};1");
            sb.AppendLine($"Окладная часть ЗП;{F(nudSalaryAdmin.Value)};1");
            sb.AppendLine($"Коммунальные услуги;{F(nudUtilities.Value)};1");
            sb.AppendLine($"Проценты по кредитам;{F(nudLoanInterest.Value)};1");
            sb.AppendLine($"Ставка соц. отчислений (%);{F(nudSocialRate.Value)};1");
            sb.AppendLine($"Налог на прибыль (%);{F(nudProfitTaxRate.Value)};1");

            // === ВКЛАДКА 3: Детальная структура ===
            sb.AppendLine($"Прямые: Сырье (ед.);{F(nudRawMaterialsDirect.Value)};3");
            sb.AppendLine($"Прямые: ЗП основного (ед.);{F(nudMainLaborWage.Value)};3");
            sb.AppendLine($"Общепроизв.: ЗП вспомогательного;{F(nudAuxiliaryLaborWage.Value)};3");
            sb.AppendLine($"Общепроизв.: Тех. энергия/вода;{F(nudTechnologicalEnergy.Value)};3");
            sb.AppendLine($"Общепроизв.: Прочие (%);{F(nudOtherProdOverheadPerc.Value)};3");
            sb.AppendLine($"Админ: ЗП АУП;{F(nudAdminStaffWage.Value)};3");
            sb.AppendLine($"Админ: Аренда;{F(nudRentAdmin.Value)};3");
            sb.AppendLine($"Админ: Отопление;{F(nudHeating.Value)};3");
            sb.AppendLine($"Админ: Связь;{F(nudCommunication.Value)};3");
            sb.AppendLine($"Админ: Охрана;{F(nudSecurity.Value)};3");
            sb.AppendLine($"Админ: Канцелярия;{F(nudOfficeSupplies.Value)};3");
            sb.AppendLine($"Админ: Прочие (%);{F(nudOtherAdminPerc.Value)};3");
            sb.AppendLine($"Эксплуат: Амортизация;{F(nudDepreciationCost.Value)};3");
            sb.AppendLine($"Эксплуат: Лизинг;{F(nudLeasePayments.Value)};3");
            sb.AppendLine($"Эксплуат: Проценты;{F(nudLoanInterestCost.Value)};3");
            sb.AppendLine($"Эксплуат: Налоги;{F(nudTaxesInCost.Value)};3");
            sb.AppendLine($"Коммерческие: ЗП сбыта;{F(nudSalesStaffWage.Value)};3");
            sb.AppendLine($"Коммерческие: Прочие (%);{F(nudOtherCommPerc.Value)};3");
            sb.AppendLine($"Неявные: Упущенный %;{F(nudOpportunityCapital.Value)};3");
            sb.AppendLine($"Неявные: Упущенная ЗП;{F(nudOpportunityLabor.Value)};3");
            sb.AppendLine($"Неявные: Упущенная рента;{F(nudOpportunityRent.Value)};3");
            sb.AppendLine($"Неявные: Нормальная прибыль;{F(nudNormalProfit.Value)};3");

            return sb.ToString();
        }

        // ================= IMPORT LOGIC =================

        private void BtnImportCsv_Click(object sender, EventArgs e)
        {
            try
            {
                using (var openFileDialog = new OpenFileDialog
                {
                    Filter = "CSV файлы|*.csv|Все файлы|*.*",
                    Title = "Загрузить данные из CSV",
                    CheckFileExists = true
                })
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        ImportCsvData(openFileDialog.FileName);
                        MessageBox.Show("Данные успешно загружены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка импорта: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImportCsvData(string filePath)
        {
            var lines = File.ReadAllLines(filePath, new UTF8Encoding(true));

            // Пропускаем заголовок, читаем данные
            foreach (var line in lines.Skip(1))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                var parts = line.Split(';');
                if (parts.Length < 2) continue;

                var paramName = parts[0].Trim();

                // Пробуем распарсить значение (используем инвариантную культуру, так как в CSV точка)
                if (!decimal.TryParse(parts[1], NumberStyles.Any, CultureInfo.InvariantCulture, out decimal value))
                    continue;

                // === ЗАПОЛНЕНИЕ ПОЛЕЙ ПО ИМЕНИ ===
                switch (paramName)
                {
                    // Вкладка 1
                    case "Объем выпуска (Q)": nudOutputVolume.Value = value; break;
                    case "Цена реализации (P)": nudPricePerUnit.Value = value; break;
                    case "Сырье и материалы (ед.)": nudRawMaterials.Value = value; break;
                    case "Энергия/транспорт (ед.)": nudEnergyTransport.Value = value; break;
                    case "Сдельная ЗП (ед.)": nudPieceworkWage.Value = value; break;
                    case "Аренда помещения": nudRent.Value = value; break;
                    case "Амортизация оборудования": nudDepreciation.Value = value; break;
                    case "Окладная часть ЗП": nudSalaryAdmin.Value = value; break;
                    case "Коммунальные услуги": nudUtilities.Value = value; break;
                    case "Проценты по кредитам": nudLoanInterest.Value = value; break;
                    case "Ставка соц. отчислений (%)": nudSocialRate.Value = value; break;
                    case "Налог на прибыль (%)": nudProfitTaxRate.Value = value; break;

                    // Вкладка 3
                    case "Прямые: Сырье (ед.)": nudRawMaterialsDirect.Value = value; break;
                    case "Прямые: ЗП основного (ед.)": nudMainLaborWage.Value = value; break;
                    case "Общепроизв.: ЗП вспомогательного": nudAuxiliaryLaborWage.Value = value; break;
                    case "Общепроизв.: Тех. энергия/вода": nudTechnologicalEnergy.Value = value; break;
                    case "Общепроизв.: Прочие (%)": nudOtherProdOverheadPerc.Value = value; break;
                    case "Админ: ЗП АУП": nudAdminStaffWage.Value = value; break;
                    case "Админ: Аренда": nudRentAdmin.Value = value; break;
                    case "Админ: Отопление": nudHeating.Value = value; break;
                    case "Админ: Связь": nudCommunication.Value = value; break;
                    case "Админ: Охрана": nudSecurity.Value = value; break;
                    case "Админ: Канцелярия": nudOfficeSupplies.Value = value; break;
                    case "Админ: Прочие (%)": nudOtherAdminPerc.Value = value; break;
                    case "Эксплуат: Амортизация": nudDepreciationCost.Value = value; break;
                    case "Эксплуат: Лизинг": nudLeasePayments.Value = value; break;
                    case "Эксплуат: Проценты": nudLoanInterestCost.Value = value; break;
                    case "Эксплуат: Налоги": nudTaxesInCost.Value = value; break;
                    case "Коммерческие: ЗП сбыта": nudSalesStaffWage.Value = value; break;
                    case "Коммерческие: Прочие (%)": nudOtherCommPerc.Value = value; break;
                    case "Неявные: Упущенный %": nudOpportunityCapital.Value = value; break;
                    case "Неявные: Упущенная ЗП": nudOpportunityLabor.Value = value; break;
                    case "Неявные: Упущенная рента": nudOpportunityRent.Value = value; break;
                    case "Неявные: Нормальная прибыль": nudNormalProfit.Value = value; break;
                }
            }

            // После импорта обновляем модель
            SaveFormDataToCompany();
            SaveDetailedFormData();
        }

        // ================= TAB 1: INPUT & SAVE =================


        private void BtnSaveData_Click(object sender, EventArgs e)
        {
            try
            {
                if (nudOutputVolume.Value <= 0)
                {
                    MessageBox.Show("Объем выпуска должен быть больше 0!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nudOutputVolume.Focus();
                    return;
                }
                if (nudPricePerUnit.Value <= 0)
                {
                    MessageBox.Show("Цена реализации должна быть больше 0!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nudPricePerUnit.Focus();
                    return;
                }

                SaveFormDataToCompany();
                MessageBox.Show("Данные успешно сохранены!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                if (nudOutputVolume.Value <= 0 || nudPricePerUnit.Value <= 0)
                {
                    MessageBox.Show("Проверьте ввод объёма и цены (должны быть > 0)!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFormDataToCompany();
                UpdateCostsTab();
                tabControl1.SelectedIndex = 1;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при расчете: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveFormDataToCompany()
        {
            // Базовые параметры
            _currentCompany.Production.OutputVolume = nudOutputVolume.Value;
            _currentCompany.Production.PricePerUnit = nudPricePerUnit.Value;

            // Переменные затраты
            _currentCompany.VariableCosts.RawMaterialsPerUnit = nudRawMaterials.Value;
            _currentCompany.VariableCosts.EnergyTransportPerUnit = nudEnergyTransport.Value;
            _currentCompany.VariableCosts.PieceworkWagePerUnit = nudPieceworkWage.Value;

            // Постоянные затраты
            _currentCompany.FixedCosts.Rent = nudRent.Value;
            _currentCompany.FixedCosts.Depreciation = nudDepreciation.Value;
            _currentCompany.FixedCosts.SalaryAdministrative = nudSalaryAdmin.Value;
            _currentCompany.FixedCosts.Utilities = nudUtilities.Value;
            _currentCompany.FixedCosts.LoanInterest = nudLoanInterest.Value;

            // Налоговые настройки
            _currentCompany.TaxSettings.SocialContributionRate = nudSocialRate.Value;
            _currentCompany.TaxSettings.ProfitTaxRate = nudProfitTaxRate.Value;
        }

        // ================= TAB 2: UPDATE & THEORY =================
        private void UpdateCostsTab()
        {
            try
            {
                decimal accountingCosts = _calculator.CalculateTotalCosts();
                lblAccountingCostsValue.Text = $"{accountingCosts:N2} руб.";
                lblInternalCostsValue.Text = "0 руб. (опционально)";

                lblFCValue.Text = $"{_currentCompany.FixedCosts.TotalFixedCosts:N2} руб.";
                lblVCValue.Text = $"{_calculator.GetTotalVariableCosts():N2} руб.";
                lblTCValue.Text = $"{accountingCosts:N2} руб.";

                lblAFCValue.Text = $"{_calculator.CalculateAverageFixedCost():N2} руб./шт.";
                lblAVCValue.Text = $"{_calculator.CalculateAverageVariableCost():N2} руб./шт.";
                lblATCValue.Text = $"{_calculator.CalculateAverageTotalCost():N2} руб./шт.";
                lblMCValue.Text = $"{_calculator.CalculateAverageVariableCost():N2} руб./шт.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении вкладки издержек: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= TAB 3: DETAILED CALCULATION =================
        private void BtnCalculateDetailed_Click(object sender, EventArgs e)
        {
            try
            {
                if (nudOutputVolume3.Value <= 0 || nudPricePerUnit3.Value <= 0)
                {
                    MessageBox.Show("Укажите объем выпуска и цену на вкладке 3!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveDetailedFormData();
                UpdateTab3Results();
                MessageBox.Show("Расчет себестоимости и прибыли выполнен успешно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при расчете: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveDetailedFormData()
        {
            _currentCompany.Production.OutputVolume = nudOutputVolume3.Value;
            _currentCompany.Production.PricePerUnit = nudPricePerUnit3.Value;

            _currentCompany.DirectCosts.RawMaterialsPerUnit = nudRawMaterialsDirect.Value;
            _currentCompany.DirectCosts.MainLaborWagePerUnit = nudMainLaborWage.Value;

            _currentCompany.ProductionOverhead.AuxiliaryLaborWage = nudAuxiliaryLaborWage.Value;
            _currentCompany.ProductionOverhead.TechnologicalEnergyWater = nudTechnologicalEnergy.Value;
            _currentCompany.ProductionOverhead.OtherProductionOverheadPercent = nudOtherProdOverheadPerc.Value;

            _currentCompany.AdministrativeCosts.AdministrativeStaffWage = nudAdminStaffWage.Value;
            _currentCompany.AdministrativeCosts.Rent = nudRentAdmin.Value;
            _currentCompany.AdministrativeCosts.Heating = nudHeating.Value;
            _currentCompany.AdministrativeCosts.Communication = nudCommunication.Value;
            _currentCompany.AdministrativeCosts.Security = nudSecurity.Value;
            _currentCompany.AdministrativeCosts.OfficeSupplies = nudOfficeSupplies.Value;
            _currentCompany.AdministrativeCosts.OtherAdministrativePercent = nudOtherAdminPerc.Value;

            _currentCompany.OperatingCosts.Depreciation = nudDepreciationCost.Value;
            _currentCompany.OperatingCosts.LeasePayments = nudLeasePayments.Value;
            _currentCompany.OperatingCosts.LoanInterest = nudLoanInterestCost.Value;
            _currentCompany.OperatingCosts.TaxesIncludedInCost = nudTaxesInCost.Value;

            _currentCompany.CommercialCosts.SalesStaffWage = nudSalesStaffWage.Value;
            _currentCompany.CommercialCosts.OtherCommercialPercent = nudOtherCommPerc.Value;

            _currentCompany.ImplicitCosts.OpportunityCostCapital = nudOpportunityCapital.Value;
            _currentCompany.ImplicitCosts.OpportunityCostOwnerLabor = nudOpportunityLabor.Value;
            _currentCompany.ImplicitCosts.OpportunityCostRent = nudOpportunityRent.Value;
            _currentCompany.ImplicitCosts.NormalProfit = nudNormalProfit.Value;
        }

        private void UpdateTab3Results()
        {
            valResDirect.Text = $"{_detailedCalculator.CalculateDirectCosts():N2} руб.";
            valResProdOverhead.Text = $"{_currentCompany.ProductionOverhead.TotalProductionOverhead:N2} руб.";
            valResAdmin.Text = $"{_currentCompany.AdministrativeCosts.TotalAdministrativeCosts:N2} руб.";
            valResOperating.Text = $"{_currentCompany.OperatingCosts.TotalOperatingCosts:N2} руб.";
            valResProdCost.Text = $"{_detailedCalculator.CalculateProductionCost():N2} руб.";
            valResCommercial.Text = $"{_currentCompany.CommercialCosts.TotalCommercialCosts:N2} руб.";
            valResFullCost.Text = $"{_detailedCalculator.CalculateFullCost():N2} руб.";
            valResCostPerUnit.Text = $"{_detailedCalculator.CalculateCostPerUnit():N2} руб./шт.";

            valResRevenue.Text = $"{_detailedCalculator.CalculateRevenue():N2} руб.";
            valResGrossProfit.Text = $"{_detailedCalculator.CalculateGrossProfit():N2} руб.";
            valResOperatingProfit.Text = $"{_detailedCalculator.CalculateOperatingProfit():N2} руб.";
            valResNetProfit.Text = $"{_detailedCalculator.CalculateNetProfit():N2} руб.";
            valResEconomicProfit.Text = $"{_detailedCalculator.CalculateEconomicProfit():N2} руб.";

            valResCM.Text = $"{_detailedCalculator.CalculateContributionMargin():N2} руб.";
            valResCMRatio.Text = $"{_detailedCalculator.CalculateContributionMarginRatio():N2}%";
            valResProfitability.Text = $"{_detailedCalculator.CalculateProfitabilityFullCost():N2}%";
            valResROS.Text = $"{_detailedCalculator.CalculateReturnOnSales():N2}%";

            var bepUnits = _detailedCalculator.CalculateBreakEvenPointUnits();
            var bepValue = _detailedCalculator.CalculateBreakEvenPointValue();

            if (bepUnits < 0)
            {
                valResBEPUnits.Text = "Недостижима (P ≤ AVC)";
                valResBEPValue.Text = "—";
            }
            else
            {
                valResBEPUnits.Text = $"{bepUnits:N0} шт.";
                valResBEPValue.Text = $"{bepValue:N2} руб.";
            }

            valResSafetyUnits.Text = $"{_detailedCalculator.CalculateSafetyMarginUnits():N0} шт.";
            valResSafetyPerc.Text = $"{_detailedCalculator.CalculateSafetyMarginPercent():N2}%";
        }

        private void BtnClearTab3_Click(object sender, EventArgs e)
        {
            nudOutputVolume3.Value = 0; nudPricePerUnit3.Value = 0;
            nudRawMaterialsDirect.Value = 0; nudMainLaborWage.Value = 0;
            nudAuxiliaryLaborWage.Value = 0; nudTechnologicalEnergy.Value = 0; nudOtherProdOverheadPerc.Value = 13;
            nudAdminStaffWage.Value = 0; nudRentAdmin.Value = 0; nudHeating.Value = 0;
            nudCommunication.Value = 0; nudSecurity.Value = 0; nudOfficeSupplies.Value = 0; nudOtherAdminPerc.Value = 13;
            nudDepreciationCost.Value = 0; nudLeasePayments.Value = 0; nudLoanInterestCost.Value = 0; nudTaxesInCost.Value = 0;
            nudSalesStaffWage.Value = 0; nudOtherCommPerc.Value = 13;
            nudOpportunityCapital.Value = 0; nudOpportunityLabor.Value = 0; nudOpportunityRent.Value = 0; nudNormalProfit.Value = 0;

            foreach (Control ctrl in tabPage3.Controls)
            {
                if (ctrl is Label lbl && lbl.Name.StartsWith("valRes"))
                    lbl.Text = "0 руб.";
            }
        }

        // ================= THEORY BUTTONS =================
        private static void ShowTheory(string title, string content)
        {
            MessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnInfoAccounting_Click(object sender, EventArgs e) => ShowTheory("БУХГАЛТЕРСКИЕ (ЯВНЫЕ) ИЗДЕРЖКИ",
            "Фактические денежные затраты предприятия, связанные с производственной деятельностью.\n\n" +
            "📋 Включают:\n• Материально-производственные затраты\n• Оплата труда наёмных работников\n" +
            "• Отчисления на социальные нужды (38,5% от ФОТ)\n• Амортизационные расходы\n• Прочие затраты\n\n" +
            "💰 Формула: Бухгалтерские издержки = FC + VC\n\n📊 Значение: Используются для расчёта бухгалтерской прибыли и составления финансовой отчётности.");

        private void BtnInfoInternal_Click(object sender, EventArgs e) => ShowTheory("ВНУТРЕННИЕ (НЕЯВНЫЕ) ИЗДЕРЖКИ",
            "Затраты собственных ресурсов предприятия, оценённые по наилучшему варианту альтернативного использования.\n\n" +
            "📋 Включают:\n• Упущенная зарплата владельца\n• Упущенная рента\n• Упущенный процент на капитал\n• Нормальная прибыль\n\n" +
            "📊 Значение: Используются для расчёта экономической прибыли. Показывают альтернативные издержки использования собственных ресурсов.");

        private void BtnInfoFC_Click(object sender, EventArgs e) => ShowTheory("ПОСТОЯННЫЕ ИЗДЕРЖКИ (FC)",
            "Издержки, величина которых НЕ изменяется с изменением объёма производства.\n\n" +
            "📚 Примеры: Аренда, амортизация, окладная часть ЗП, коммунальные услуги, проценты по кредитам.\n" +
            "💡 Существуют даже при нулевом выпуске (Q=0). График: горизонтальная прямая.");

        private void BtnInfoVC_Click(object sender, EventArgs e) => ShowTheory("ПЕРЕМЕННЫЕ ИЗДЕРЖКИ (VC)",
            "Издержки, которые изменяются пропорционально изменению объёма производства.\n\n" +
            "📚 Примеры: Сырьё, энергия, сдельная ЗП.\n💰 Формула: VC = AVC × Q. При Q = 0, VC = 0.");

        private void BtnInfoTC_Click(object sender, EventArgs e) => ShowTheory("СОВОКУПНЫЕ ИЗДЕРЖКИ (TC)",
            "Сумма всех постоянных и переменных издержек фирмы.\n💰 Формула: TC = FC + VC\n" +
            "Используются для расчёта прибыли (Profit = TR - TC) и определения точки безубыточности.");

        private void BtnInfoAFC_Click(object sender, EventArgs e) => ShowTheory("СРЕДНИЕ ПОСТОЯННЫЕ ИЗДЕРЖКИ (AFC)",
            "Постоянные издержки в расчёте на единицу продукции.\n💰 Формула: AFC = FC / Q\n" +
            "📈 Постоянно снижаются с ростом объёма производства (эффект масштаба).");

        private void BtnInfoAVC_Click(object sender, EventArgs e) => ShowTheory("СРЕДНИЕ ПЕРЕМЕННЫЕ ИЗДЕРЖКИ (AVC)",
            "Переменные издержки в расчёте на единицу продукции.\n💰 Формула: AVC = VC / Q\n" +
            "⚠️ Если P < AVC - фирме следует прекратить производство в краткосрочном периоде!");

        private void BtnInfoATC_Click(object sender, EventArgs e) => ShowTheory("СРЕДНИЕ СОВОКУПНЫЕ ИЗДЕРЖКИ (ATC)",
            "Совокупные издержки в расчёте на единицу продукции (себестоимость).\n💰 Формула: ATC = TC / Q = AFC + AVC\n" +
            "📈 U-образная кривая. Сравнение с ценой определяет прибыль или убыток.");

        private void BtnInfoMC_Click(object sender, EventArgs e) => ShowTheory("ПРЕДЕЛЬНЫЕ ИЗДЕРЖКИ (MC)",
            "Дополнительные издержки на производство каждой дополнительной единицы продукции.\n💰 Формула: MC = ΔTC / ΔQ\n" +
            "Правило максимизации прибыли: MR = MC. В условиях совершенной конкуренции: P = MC.");

        private void BtnInfoCostStructure_Click(object sender, EventArgs e) => ShowTheory("СТРУКТУРА СЕБЕСТОИМОСТИ (Положение РФ №552)",
            "1️⃣ ПРЯМЫЕ ЗАТРАТЫ: Сырьё, ЗП основного персонала, соц. отчисления (38.5%)\n" +
            "2️⃣ ОБЩЕПРОИЗВОДСТВЕННЫЕ: ЗП вспомогательного, тех. энергия/вода, прочие (~13%)\n" +
            "3️⃣ ОБЩЕЗАВОДСКИЕ: ЗП АУП, аренда, отопление, связь, охрана, канцелярия, прочие (~13%)\n" +
            "4️⃣ ЭКСПЛУАТАЦИОННЫЕ: Амортизация, лизинг, проценты, налоги на себестоимость\n" +
            "= ПРОИЗВОДСТВЕННАЯ СЕБЕСТОИМОСТЬ\n" +
            "5️⃣ КОММЕРЧЕСКИЕ: ЗП сбыта + соц. отчисления, прочие (~13%)\n" +
            "= ПОЛНАЯ СЕБЕСТОИМОСТЬ");

        // ================= TAB 4: CHARTS =================

        private void BtnRefreshCharts_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedIndex == 0)
                    SaveFormDataToCompany();
                else if (tabControl1.SelectedIndex == 2)
                    SaveDetailedFormData();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при отрисовке графиков: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}