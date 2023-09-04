import { Component, OnInit } from '@angular/core';
import { EcommerceService } from './lECommerce.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.sass']
})
export class LoginComponent implements OnInit{


  constructor(private loginService: EcommerceService,private formBuilder: FormBuilder,private router: Router)
  {  
  }

  showErrors = false;

  loginForm!: FormGroup;

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      userName: new FormControl('',[Validators.required]),
      password: new FormControl('',[Validators.minLength(6),Validators.required])
    })
  }

  onClickLogin()
  {
    const name =this.loginForm.get('userName')?.value!;
    const password =this.loginForm.get('password')?.value!;

    this.loginService.Login(name,password).subscribe({
      next: () => { this.router.navigate(['./product-list']); },
      error: () => { alert('Insert valid Username or Password'); }
    });
  }

}
