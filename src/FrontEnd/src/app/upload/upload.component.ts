import { Component, OnInit, EventEmitter } from '@angular/core';
import { FileUploader } from 'ng2-file-upload';
import { Inject, Injectable, Optional, Input } from '@angular/core';
import { BASE_PATH } from '../swagger/variables';
import { UploadOutput, UploadInput, UploadFile, humanizeBytes } from 'ngx-uploader';
import { environment } from '../../environments/environment';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
export class UploadComponent implements OnInit {
@Input() controller: string;
@Input() action: string;

  public uploader: FileUploader;
  public hasBaseDropZoneOver = false;
  public hasAnotherDropZoneOver = false;
  image: any;
  formData: FormData;
  files: UploadFile[];
  uploadInput: EventEmitter<UploadInput>;
  humanizeBytes: Function;
  dragOver: boolean;

  constructor(@Optional()@Inject(BASE_PATH) private basePath: string){
    this.files = []; // local uploading files array
    this.uploadInput = new EventEmitter<UploadInput>(); // input events, we use this to emit data to ngx-uploader
    this.humanizeBytes = humanizeBytes;
  }

  onStatusChange(file: any) {
  this.handleFileSelect(this.uploader.queue[0]);

  console.log(file);
}

handleFileSelect(evt) {
  const files = evt.target.files;
  const file = files[0];

  if (files && file) {
    const reader = new FileReader();

    reader.onload = this._handleReaderLoaded.bind(this);

    reader.readAsBinaryString(file);
  }
}

_handleReaderLoaded(readerEvt) {
  const binaryString = readerEvt.target.result;
  const base64textString = btoa(binaryString);
  console.log(btoa(binaryString));
}

  public fileOverBase(e: any): void {
    this.hasBaseDropZoneOver = e;
  }

  public fileOverAnother(e: any): void {
    this.hasAnotherDropZoneOver = e;
  }

  ngOnInit() {
    const url = `${environment.apiUrl}/api/${this.controller}/${this.action}`;

    this.uploader = new FileUploader({ url: url, isHTML5: true, authToken: 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJNaWNrZXlNb3VzZSIsImp0aSI6ImZhZDJjYTMwLWU4NTYtNDAyMi1iMDg5LTQ2NDMxYTk4NDk5YyIsImlhdCI6MTUwMjM4NjQxNSwiTXVsdGFzQ2hhcmFjdGVyIjoiTXVsdGFzQWNvbXBhbmhhZGFzIiwibmJmIjoxNTAyMzg2NDE1LCJleHAiOjE1MDI0NzI4MTUsImlzcyI6IlN1cGVyQXdlc29tZVRva2VuU2VydmVyIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDoxNzgzLyJ9.-eATTo24A3rc5BXNioT-H-rYLIzoYislwMPT6MMrlzc' });
  }
}
