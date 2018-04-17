<style lang="less">
@import "./login.less";
</style>

<template>
  <div class="login" @keydown.enter="handleSubmit">
    <div class="login-con">
      <el-card :bordered="false">
        <el-row>
          <el-col :span="20">
            <p>
              <Icon type="log-in"></Icon>
              <span v-if="isMultiTenancyEnabled" class="multi-tenancy">{{'CurrentTenant'|l}}:
                <span v-if="tenant" class="tenant-name"> {{tenant.name}}</span>
                <span v-if="!tenant"> {{'NotSelected'|l}}</span>
              </span>
            </p>
          </el-col>
          <el-col :span="4">
            <a href="#" @click="showChangeModal">
              {{'Change'|l}}
            </a>
          </el-col>
        </el-row>
        <div class="form-con">
          <el-form ref="loginForm" :model="form" :rules="rules">
            <el-form-item>
              <el-input v-model="form.userNameOrEmailAddress" :placeholder="'UserNameOrEmail'|l">
                <span>
                  <i class="ion-person"></i>
                </span>
              </el-input>
            </el-form-item>
            <el-form-item prop="password">
              <el-input type="password" v-model="form.password" :placeholder="'Password'|l">
                <span>
                  <i class="ion-locked"></i>
                </span>
              </el-input>
            </el-form-item>
            <div style="margin-bottom:10px">
              <el-checkbox v-model="form.rememberClient">{{'RememberMe'|l}}</el-checkbox>
            </div>
            <el-form-item>
              <el-button @click="handleSubmit" type="primary" style="width:100%;">{{'LogIn'|l}}</el-button>
            </el-form-item>
          </el-form>
          <div>
            <ul class="language-ul">
              <li v-for="language in languages" v-if="language.displayName!==currentLanguage.displayName" @click="changeLanguage(language.name)">
                <el-tooltip :content="language.displayName" placement="bottom">
                  <a>
                    <i :class="language.icon"></i>
                  </a>
                </el-tooltip>
              </li>
            </ul>
          </div>
          <p class="login-tip">{{'PleaseEnterLoginInformation'|l}}</p>
        </div>
      </el-card>
    </div>
    <el-dialog :title="'ChangeTenant'|l" :visible.sync="modalShow" @on-ok="changeTenant">
      <el-input :placeholder="'TenancyName' | l" v-model="changedTenancyName">
      </el-input>
      <p>{{'LeaveEmptyToSwitchToHost' | l}}</p>
      <div slot="footer">
        <el-button @click="modalShow=false">{{'Cancel'|l}}</el-button>
        <el-button @click="changeTenant" type="primary">{{'Save'|l}}</el-button>
      </div>
    </el-dialog>
  </div>
</template>

<script>
import Cookies from "js-cookie";
export default {
  data() {
    return {
      languages: [],
      currentLanguage: {},
      isMultiTenancyEnabled: abp.multiTenancy.isEnabled,
      changedTenancyName: "",
      modalShow: false,
      isMultiTenancyEnabled: true,
      form: {
        userNameOrEmailAddress: "",
        password: "",
        rememberClient: false
      },
      rules: {
        userNameOrEmailAddress: [
          {
            required: true,
            message: this.L("ThisFieldIsRequired"),
            trigger: "blur"
          }
        ],
        password: [
          {
            required: true,
            message: this.L("ThisFieldIsRequired"),
            trigger: "blur"
          }
        ]
      }
    };
  },
  methods: {
    changeLanguage(languageName) {
      abp.utils.setCookieValue(
        "Abp.Localization.CultureName",
        languageName,
        new Date(new Date().getTime() + 5 * 365 * 86400000), //5 year
        abp.appPath
      );
      location.reload();
    },
    showChangeModal() {
      this.modalShow = true;
    },
    async changeTenant() {
      if (!this.changedTenancyName) {
        abp.multiTenancy.setTenantIdCookie(undefined);
        this.modalShow = false;
        location.reload();
        return;
      } else {
        let tenant = await this.$store.dispatch({
          type: "account/isTenantAvailable",
          data: { tenancyName: this.changedTenancyName }
        });
        switch (tenant.state) {
          case 1:
            abp.multiTenancy.setTenantIdCookie(tenant.tenantId);
            location.reload();
            return;
          case 2:
            let message = this.L("TenantIsNotActive", this.changedTenancyName);
            this.$Modal.error({
              title: "",
              content: message
            });
            break;
          case 3:
            let message2 = this.L(
              "ThereIsNoTenantDefinedWithName{0}",
              this.changedTenancyName
            );
            this.$Modal.error({
              title: "",
              content: message2
            });
            break;
        }

        this.modalShow = false;
        this.modalShow = true;
      }
    },
    async handleSubmit() {
      this.$refs.loginForm.validate(async valid => {
        if (valid) {
          const loading = this.$loading({
            lock: true,
            text: this.L("PleaseWait"),
            spinner: 'el-icon-loading',
            background: 'rgba(0, 0, 0, 0.7)'
          });

          let self = this;

          await this.$store
            .dispatch({
              type: "user/login",
              data: self.form
            })
            .then(
            response => {
              Cookies.set(
                "userNameOrEmailAddress",
                self.form.userNameOrEmailAddress
              );
              location.reload();
            },
            error => {
              // this.$alert('登录失败', '错误', {
              //   confirmButtonText: '确定',
              //   type:'error',
              // });

              loading.close();
            }
            );
        }
      });
    }
  },
  created() {
    this.languages = abp.localization.languages.filter(val => {
      return !val.isDisabled;
    });
    this.currentLanguage = abp.localization.currentLanguage;
    this.isMultiTenancyEnabled = abp.multiTenancy.isEnabled;
  },
  computed: {
    tenant() {
      return this.$store.state.session.tenant;
    }
  }
};
</script>

<style>
.language-ul {
  text-align: center;
}
.language-ul li {
  display: inline;
  margin: 2px;
}
.famfamfam-flags {
  display: inline-block;
}
</style>
