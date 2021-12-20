import {
  Component,
  Injector,
  OnInit,
  Output,
  EventEmitter
} from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/app-component-base';
import {
  CategoriesServiceProxy,
  CategoryDto,
  ProductDto,
  ProductsServiceProxy,
  ProductTranslationDto
} from '@shared/service-proxies/service-proxies';
import { filter as _filter } from 'lodash-es';

@Component({
  templateUrl: 'create-product-dialog.component.html'
})
export class CreateProductDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  product: ProductDto = new ProductDto();
  languages: abp.localization.ILanguageInfo[];
  currentLanguage: abp.localization.ILanguageInfo;
  langTranslation: ProductTranslationDto[] = [];
  categories: CategoryDto[] = [];

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    private _productService: ProductsServiceProxy,
    private _categoryService: CategoriesServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this.languages = _filter(
      this.localization.languages,
      (l) => !l.isDisabled
    );
    this.currentLanguage = this.localization.currentLanguage;
    this.languages.forEach(lang => {
      this.langTranslation[lang.name] = ProductTranslationDto.fromJS({
        language: lang.name
      });
    });

    this._categoryService.getAll('', 0, 100).subscribe(res => this.categories = res.items);
  }

  save(): void {
    this.saving = true;
    
    this.product.translations = Object.keys(this.langTranslation).map(k => {
      if (this.langTranslation[k].name) {
        return this.langTranslation[k];
      } 
    }).filter(el => el);
    
    this._productService.create(this.product).subscribe(
      () => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
      },
      () => {
        this.saving = false;
      }
    );
  }
}
