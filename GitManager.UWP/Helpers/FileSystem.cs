using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace GitManager.UWP.Helpers
{
    public static class FileSystem
    {
        public static class Dialog
        {
            public enum FileAction_T
            {
                OPEN,
                SAVE
            }

            public enum Dialog_T
            {
                SINGLE_FILE,
                SINGLE_DIRECTORY,
                MULTI_FILE,
                MULTI_DIRECTORY
            }

            public static async Task<List<StorageFile>> File (Dialog_T FileDialogType, FileAction_T FileActionType, Dictionary<string, List<string>> Extensions = null)
            {
                List<StorageFile> SelectedFiles = new List<StorageFile>();

                if (FileActionType == FileAction_T.OPEN)
                {

                    FileOpenPicker filePicker = new FileOpenPicker
                    {
                        SuggestedStartLocation = PickerLocationId.ComputerFolder,
                        ViewMode = PickerViewMode.Thumbnail,
                    };

                    if (Extensions != null)
                    {
                        foreach (List<string> ExtensionList in Extensions.Values)
                        {
                            foreach(string Extension in ExtensionList)
                            filePicker.FileTypeFilter.Add(Extension);
                        }
                    }

                    switch (FileDialogType)
                    {
                        case Dialog_T.SINGLE_FILE:

                            SelectedFiles.Add(await filePicker.PickSingleFileAsync());

                            return SelectedFiles;

                        case Dialog_T.MULTI_FILE:

                            foreach (StorageFile file in await filePicker.PickMultipleFilesAsync())
                            {
                                SelectedFiles.Add(file);
                            }

                            return SelectedFiles;

                        default:
                            return SelectedFiles;
                    }
                }
                else
                {
                    FileSavePicker filePicker = new FileSavePicker
                    {
                        SuggestedStartLocation = PickerLocationId.ComputerFolder
                    };

                    if (Extensions != null)
                    {
                        filePicker.DefaultFileExtension = Extensions.First().Value.First();

                        foreach(KeyValuePair<string, List<string>> Extension in Extensions)
                        {
                            filePicker.FileTypeChoices.Add(Extension.Key, Extension.Value);
                        }

                        filePicker.SuggestedFileName = Assembly.GetExecutingAssembly().GetName().Name + "_File_" + DateTime.Now.ToString("M-d-y");
                    }

                    switch (FileDialogType)
                    {
                        case Dialog_T.SINGLE_FILE:

                            SelectedFiles.Add(await filePicker.PickSaveFileAsync());

                            return SelectedFiles;

                        default:
                            return SelectedFiles;
                    }
                }
            }

            public static async Task<List<StorageFolder>> Folder (Dialog_T FolderDialogType, List<string> Extensions = null)
            {
                List<StorageFolder> SelectedFolders = new List<StorageFolder>();

                FolderPicker folderPicker = new FolderPicker
                {
                    SuggestedStartLocation = PickerLocationId.ComputerFolder,
                    ViewMode = PickerViewMode.Thumbnail,
                };

                if (Extensions != null)
                {
                    foreach (string extension in Extensions)
                    {
                        folderPicker.FileTypeFilter.Add(extension);
                    }
                }

                StorageFolder RootFolder = await folderPicker.PickSingleFolderAsync();

                switch (FolderDialogType)
                {
                    case Dialog_T.SINGLE_DIRECTORY:

                        SelectedFolders.Add(RootFolder);

                        return SelectedFolders;

                    case Dialog_T.MULTI_DIRECTORY:

                        foreach (StorageFolder folder in await RootFolder.GetFoldersAsync())
                        {
                            SelectedFolders.Add(folder);
                        }

                        return SelectedFolders;

                    default:
                        return SelectedFolders;
                }
            }
        }
    }
}
