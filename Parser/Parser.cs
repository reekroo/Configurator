﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

using NLog;

using Parser.Entities;
using Parser.Functionalities;
using Parser.Interfaces;
using Parser.Resources;

namespace Parser
{
    public class Parser : IParser
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private readonly XElement _document;

        private readonly Add _add = new Add();

        private readonly Extract _extract = new Extract();

        private readonly Remove _remove = new Remove();

        private readonly Replace _replace = new Replace();

        public Parser(XElement doc)
        {
            _document = doc;
        }

        public IEnumerable<Element> Extract()
        {
            var pdfElements = _extract.ExtractPdfs(ConstPath.Pdfs, _document);
            Logger.Log(LogLevel.Trace, "Extracted Pdfs From Config File");

            var formElements = _extract.ExtractForms(ConstPath.Forms, _document);
            Logger.Log(LogLevel.Trace, "Extracted Forms From Config File");

            var result = formElements.Select(form => new Element(form)
            {
                PdfFilePath = pdfElements.Any(pdf => form.PdfName == pdf.PdfName) ? pdfElements.First(pdf => form.PdfName == pdf.PdfName).PdfFilePath : string.Empty,
                UsedPackages = _extract.ExtractUsedPackages(ConstPath.FormsInPackages, _document, form.FormName) ?? Enumerable.Empty<string>(),
                UnusedPackages = _extract.ExtractUnusedPackages(ConstPath.FormsInPackages, _document, form.FormName) ?? Enumerable.Empty<string>()
            });
            Logger.Log(LogLevel.Trace, "Extracted Packages For Forms From Config File");

            Logger.Log(LogLevel.Info, "Extracted Config File");
            return result;
        }

        public IEnumerable<string> ExtractPackages()
        {
            try
            {
                var result = _extract.ExtractPackages(ConstPath.Packages, _document);

                Logger.Log(LogLevel.Trace, "Extracted All Packages From Config File");
                Logger.Log(LogLevel.Info, "Extracted All Packages From Config File");

                return result;
            }
            catch (Exception ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                return new List<string>();
            }
        }

        public IEnumerable<string> ExtractPackageForms(string package)
        {
            if (string.IsNullOrEmpty(package))
            {
                return Enumerable.Empty<string>();
            }

            var result = _extract.ExtractFormsFromPackage(ConstPath.Packages, _document, package);
            Logger.Log(LogLevel.Info, "Extracted Forms For Packages From Config File");

            return result;
        }

        public XElement Add(Element param)
        {
            if (param == null)
            {
                return null;
            }

            var doc = _document;
            try
            {
                _add.AddToPackages(ConstPath.Packages, _document, param);
                Logger.Log(LogLevel.Trace, "Added Information To All Packages In Config File");

                _add.AddToForms(ConstPath.Form, _document, param);
                Logger.Log(LogLevel.Trace, "Added Information To Forms In Config File");

                _add.AddToPdfs(ConstPath.Pdf, _document, param);
                Logger.Log(LogLevel.Trace, "Added Information To Pdfs In Config File");

                Logger.Log(LogLevel.Info, "Added Information To Config File");

                return _document;
            }
            catch (Exception ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                return doc;
            }
        }

        public XElement Remove(Element param)
        {
            if (param == null)
            {
                return null;
            }

            var doc = _document;
            try
            {
                _remove.RemoveFromPdfs(ConstPath.Pdfs, _document, param);
                Logger.Log(LogLevel.Trace, "Removed Information From Pdfs In Config File");

                _remove.RemoveFromForms(ConstPath.Forms, _document, param);
                Logger.Log(LogLevel.Trace, "Removed Information From Forms In Config File");

                _remove.RemoveFromPackages(ConstPath.FormsInPackages, _document, param);
                Logger.Log(LogLevel.Trace, "Removed Information From All Packages In Config File");

                Logger.Log(LogLevel.Info, "Removed Information From Config File");

                return _document;
            }
            catch (Exception ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);
                return doc;
            }
        }

        public XElement Edit(Element oldParam, Element newParam)
        {
            if (oldParam == null || newParam == null)
            {
                return null;
            }

            var doc = _document;
            try
            {
                _replace.ReplaceInPdfs(ConstPath.Pdfs, _document, oldParam, newParam);
                Logger.Log(LogLevel.Trace, "Edited Information In Pdfs In Config File");

                _replace.ReplaceInForms(ConstPath.Forms, _document, oldParam, newParam);
                Logger.Log(LogLevel.Trace, "Edited Information In Forms In Config File");

                _replace.ReplaceInPackages(ConstPath.FormsInPackages, _document, oldParam, newParam);
                Logger.Log(LogLevel.Trace, "Edited Information In Packages In Config File");

                Logger.Log(LogLevel.Info, "Edited Information In Config File");

                return _document;
            }
            catch (Exception ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);
                return doc;
            }
        }

        public XElement EditPackageForms(string package, IEnumerable<string> newFormName)
        {
            if (string.IsNullOrEmpty(package) || newFormName == null || newFormName.Count() <= 0)
            {
                return null;
            }

            var doc = _document;
            try
            {
                _replace.ReplacePackageForms(ConstPath.FormsInPackages, _document, package, newFormName);
                Logger.Log(LogLevel.Info, "Edited Forms For Packages In Config File");

                return _document;
            }
            catch (Exception ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);
                return doc;
            }
        }
    }
}
