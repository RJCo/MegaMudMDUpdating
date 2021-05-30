using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace MegaMudMDCreator
{
    public class MDFileReader
    {
        public static List<T> FileReader<T>(string file) where T : struct
        {
            return ReadMDFile<T>(file);
        }

        public static List<string> RoomsFileReader(string file)
        {
            try
            {
                List<string> rooms = new List<string>();
                string line = string.Empty;
                StreamReader fileStream = new StreamReader(file);
                while ((line = fileStream.ReadLine()) != null)
                {
                    rooms.Add(line);
                }
                fileStream.Close();

                return rooms;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Reading file {file} failed:  {e.Message}");
            }

            return null;
        }

        private const int CHUNK_SIZE = 0x400;  // 1024 bytes; MD page size
        private static List<T> ReadMDFile<T>(string file) where T : struct
        {
            try
            {
                if (!File.Exists(file))
                {
                    Console.WriteLine($"{file} doesn't exist!");
                    return null;
                }

                var parsedRawData = new List<T>();

                using (var reader = new BinaryReader(File.OpenRead(file)))
                {
                    // read 0x400 bytes at a time
                    byte[] currentBlock;
                    while ((currentBlock = reader.ReadBytes(CHUNK_SIZE)) != null)
                    {
                        if (currentBlock.Length < CHUNK_SIZE)
                        {
                            // EOF Reached
                            break;
                        }

                        int i = 0;
                        // if the 0x400 starts with 01, skip it
                        // if the 0x400 begins with 00 00 xx, parse it and print to console or file
                        if (currentBlock[i] != 0x00)
                        {
                            continue;
                        }

                        int rowCount = currentBlock[i + 2];

                        // first record will be i+12
                        int nextLocation = i + 12;
                        while (nextLocation > 0)
                        {
                            if (currentBlock[nextLocation] == 0x00)
                            {
                                nextLocation = 0;
                                continue;
                            }

                            int rowLength = currentBlock[nextLocation];

                            int structStarts = -1;
                            for (int j = nextLocation; j < currentBlock.Length; j++)
                            {
                                // Find the location of 0x80 -- the struct starts next
                                if (currentBlock[j] == 0x80)
                                {
                                    structStarts = j;
                                    break;
                                }
                            }

                            if (structStarts < 0)
                            {
                                Console.WriteLine($"Unable to find the next record in the MD file {file}");
                                return null;
                            }

                            int recordSize = Marshal.SizeOf(typeof(T));

                            //currentBlock[i] to currentBlock[i+ recordSize]
                            byte[] bytes = new byte[recordSize];
                            Array.Copy(currentBlock, structStarts, bytes, 0, recordSize);

                            //Console.WriteLine($"bytes:");
                            //for (int j = 0; j < bytes.Length; j++)
                            //{
                            //    Console.Write($"{bytes[j]:X2} ");
                            //}
                            //Console.WriteLine("");

                            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
                            T item = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
                            handle.Free();

                            parsedRawData.Add(item);
                            nextLocation += rowLength + 1;
                        }
                    }
                }
                return parsedRawData;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Reading file {file} failed:  {e.Message}");
            }

            return null;
        }

        //private static List<List<byte>> ReadMDFile(string file)
        //{
        //    try
        //    {
        //        var parsedRawData = new List<List<byte>>();

        //        using (var fsSource = new FileStream(file, FileMode.Open, FileAccess.Read))
        //        {
        //            // Read the source file into a byte array.
        //            byte[] bytes = new byte[fsSource.Length];
        //            int numBytesToRead = (int)fsSource.Length;
        //            int numBytesRead = 0;
        //            while (numBytesToRead > 0)
        //            {
        //                // Read may return anything from 0 to numBytesToRead.
        //                int n = fsSource.Read(bytes, numBytesRead, numBytesToRead);

        //                // Break when the end of the file is reached.
        //                if (n == 0)
        //                    break;

        //                numBytesRead += n;
        //                numBytesToRead -= n;
        //            }

        //            // read 0x400 bytes at a time
        //            for (int i = 0; i < bytes.Length - 1; i += 0x400)
        //            {
        //                // if the 0x400 starts with 01, skip it
        //                // if the 0x400 begins with 00 00 xx, parse it and print to console or file
        //                if (bytes[i] != 0x00)
        //                {
        //                    continue;
        //                }

        //                int rowCount = bytes[i + 2];

        //                // first record will be i+12
        //                int nextLocation = i + 12;
        //                while (nextLocation > 0)
        //                {
        //                    if (bytes[nextLocation] == 0x00)
        //                    {
        //                        nextLocation = 0;
        //                        continue;
        //                    }

        //                    int rowLength = bytes[nextLocation];

        //                    var hexOutput = string.Empty;
        //                    var rowInformation = new List<byte>();
        //                    for (int j = 0; j < rowLength; j++)
        //                    {
        //                        hexOutput += string.Format("{0:X2} ", bytes[nextLocation + j]);
        //                        rowInformation.Add(bytes[nextLocation + j]);
        //                    }

        //                    //Console.WriteLine(hexOutput);
        //                    parsedRawData.Add(rowInformation);
        //                    nextLocation += rowLength + 1;
        //                }
        //            }

        //        }
        //        return parsedRawData;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine($"Reading file {file} failed:  {e.Message}");
        //    }

        //    return null;
        //}
    }
}
