import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from './Login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.sass']
})
export class LoginComponent implements OnInit {


  constructor(private loginService: LoginService, private formBuilder: FormBuilder, private router: Router) {
  }

  showErrors = false;

  loginForm!: FormGroup;

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      userName: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.minLength(6), Validators.required])
    })
  }

  onClickLogin() {
    const name = this.loginForm.get('userName')?.value!;
    const password = this.loginForm.get('password')?.value!;

    this.loginService.Login(name,password).subscribe({
      next: (response)=> {
        if(response === true){
          this.router.navigate(['./product-list']);
        }
        else{
          alert('Insert valid Username or Password');
        }
      }
    })
  }

}
